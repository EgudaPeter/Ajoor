﻿using Ajoor.Core;
using Ajoor.DTO;
using Ajoor.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class SuperAdminDebitCustomer : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        static long selectedID = 0;
        public SuperAdminDebitCustomer()
        {
            InitializeComponent();
        }

        private void bgwGetCustomers_DoWork(object sender, DoWorkEventArgs e)
        {
            cmb_Customers.Invoke(new MethodInvoker(delegate
            {
                cmb_Customers.DataSource = _CustomerRepo.GetAllRecords().Select(x => new { x.CustomerId, x.LastName, x.FirstName, x.AccountNumber, x.FullName }).ToList();
                cmb_Customers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb_Customers.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb_Customers.DisplayMember = "FullName";
                cmb_Customers.ValueMember = "CustomerId";
                cmb_Customers.SelectedIndex = -1;
            }));
        }

        private void bgwGetRecords_DoWork(object sender, DoWorkEventArgs e)
        {
            dgv_CustomerTransactions.Invoke(new MethodInvoker(delegate
            {
                dgv_CustomerTransactions.DataSource = _TransactionRepo.GetDebitTransactions().Where(x => x.CustomerId == selectedID && x.CreatedBy == Utilities.USERNAME).ToList();
            }));
            lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerTransactions.RowCount.ToString(); }));
            e.Result = "Done";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Leave form?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Close();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void cmb_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ID = cmb_Customers.SelectedValue.ToString();
                var customer = _CustomerRepo.GetCustomer(long.Parse(ID));
                var customerTransaction = _TransactionRepo.GetAllTransactions()
                      .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                txt_AccountNumber.Text = customer.AccountNumber.ToString();
                selectedID = long.Parse(ID); txt_Commission.Text = Utilities.CurrencyFormat(customer.Commission.ToString());
                txt_TotalDebt.Text = Utilities.CurrencyFormat(customerTransaction != null ? customerTransaction.TotalDebt.ToString() : 0m.ToString());
                if (!bgwGetRecords.IsBusy)
                {
                    bgwGetRecords.RunWorkerAsync();
                }
            }
            catch (Exception ex) { }
        }

        private void DebitCustomer_Load(object sender, EventArgs e)
        {
            txt_AccountNumber.ReadOnly = true; txt_Commission.ReadOnly = true;
            txt_TotalDebt.ReadOnly = true;
            if (!bgwGetCustomers.IsBusy)
            {
                bgwGetCustomers.RunWorkerAsync();
            }
        }

        private void btn_Debit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Customers.SelectedValue != null)
                {
                    if (txt_AmountCollected.Text != string.Empty)
                    {
                        var money = Utilities.CurrencyFormat(txt_AmountCollected.Text);
                        txt_AmountCollected.Text = Utilities.RemoveCommasAndDots(txt_AmountCollected.Text);
                        var customer = _CustomerRepo.GetCustomer(int.Parse(cmb_Customers.SelectedValue.ToString()));
                        var customerTransaction = _TransactionRepo.GetAllTransactions()
                            .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                        if (customerTransaction != null)
                        {
                            if (decimal.Parse(txt_AmountCollected.Text) <= customerTransaction.AmountPayable)
                            {
                                Transactions transactions = new Transactions()
                                {
                                    CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                                    AmountContributed = 0m,
                                    AmountCollected = decimal.Parse(txt_AmountCollected.Text),
                                    TransactionType = "Debit",
                                    Date = DateTime.Now,
                                    Commission = 0m,
                                    AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                    CreatedBy = Utilities.USERNAME,
                                    CreatedDate = DateTime.Now
                                };
                                if (_TransactionRepo.DebitTransaction(transactions))
                                {
                                    MessageBox.Show("Customer debited successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (!bgwGetRecords.IsBusy)
                                    {
                                        bgwGetRecords.RunWorkerAsync();
                                    }
                                }
                            }
                            else
                            {
                                var debt = decimal.Parse(txt_AmountCollected.Text) - customerTransaction.AmountPayable;
                                var debtMoney = Utilities.CurrencyFormat(debt.ToString());
                                switch (MessageBox.Show($"You are about to loan {debtMoney} to {customer.FullName}. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                                {
                                    case DialogResult.Yes:
                                        Transactions transactions = new Transactions()
                                        {
                                            CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                                            AmountContributed = 0m,
                                            AmountCollected = decimal.Parse(txt_AmountCollected.Text),
                                            TransactionType = "Debit",
                                            Date = DateTime.Now,
                                            Commission = 0m,
                                            AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                            Debt = debt,
                                            TotalDebt = customerTransaction.TotalDebt.HasValue ? customerTransaction.TotalDebt + debt + customer.Commission : debt + customer.Commission,
                                            CreatedBy = Utilities.USERNAME,
                                            CreatedDate = DateTime.Now
                                        };
                                        if (_TransactionRepo.DebitTransaction(transactions))
                                        {
                                            MessageBox.Show($"Customer has been loaned the sum of {debtMoney} successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            var totalDebt = _TransactionRepo.GetAllTransactions()
                                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                                            txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt);
                                            if (!bgwGetRecords.IsBusy)
                                            {
                                                bgwGetRecords.RunWorkerAsync();
                                            }
                                        }
                                        break;
                                    case DialogResult.No:
                                        return;
                                }
                            }
                        }
                        else
                        {
                            var debt = decimal.Parse(txt_AmountCollected.Text);
                            var debtMoney = Utilities.CurrencyFormat(debt.ToString());
                            switch (MessageBox.Show($"You are about to loan {debtMoney} to {customer.FullName}. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {
                                case DialogResult.Yes:
                                    Transactions transactions = new Transactions()
                                    {
                                        CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                                        AmountContributed = 0m,
                                        AmountCollected = decimal.Parse(txt_AmountCollected.Text),
                                        TransactionType = "Debit",
                                        Date = DateTime.Now,
                                        Commission = 0m,
                                        AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                        Debt = debt,
                                        TotalDebt = customerTransaction != null ? customerTransaction.TotalDebt + debt + customer.Commission : debt + customer.Commission,
                                        CreatedBy = Utilities.USERNAME,
                                        CreatedDate = DateTime.Now
                                    };
                                    if (_TransactionRepo.DebitTransaction(transactions))
                                    {
                                        MessageBox.Show($"Customer has been loaned the sum of {debtMoney} successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        var totalDebt = _TransactionRepo.GetAllTransactions()
                                            .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                                        txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt);
                                        if (!bgwGetRecords.IsBusy)
                                        {
                                            bgwGetRecords.RunWorkerAsync();
                                        }
                                    }
                                    break;
                                case DialogResult.No:
                                    return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter an amount!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_AmountCollected.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to debit!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebitCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Leave form?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void txt_AmountCollected_Enter(object sender, EventArgs e)
        {
            txt_AmountCollected.Text = Utilities.RemoveCommasAndDots(txt_AmountCollected.Text);
        }

        private void txt_AmountCollected_Leave(object sender, EventArgs e)
        {
            txt_AmountCollected.Text = Utilities.CurrencyFormat(txt_AmountCollected.Text);
        }

        private void txt_AmountCollected_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Debit_Click(this, new EventArgs());
            }
        }

        private void btn_ChargeCommission_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Customers.SelectedValue != null)
                {
                    var customerId = int.Parse(cmb_Customers.SelectedValue.ToString());
                    var customer = _CustomerRepo.GetCustomer(customerId);
                    var commission = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == customerId && x.Commission == customer.Commission && x.Date.Value.Month == DateTime.Now.Month).FirstOrDefault();
                    if (commission == null)
                    {
                        Transactions transactions = new Transactions()
                        {
                            CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                            AmountContributed = 0m,
                            AmountCollected = 0m,
                            TransactionType = "Commission Charge",
                            Date = DateTime.Now,
                            Commission = customer.Commission,
                            AmountPayable = 0m,
                            CreatedBy = Utilities.USERNAME,
                            CreatedDate = DateTime.Now
                        };
                        if (_TransactionRepo.DebitTransaction(transactions))
                        {
                            MessageBox.Show($"Commission has been charged successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!bgwGetRecords.IsBusy)
                            {
                                bgwGetRecords.RunWorkerAsync();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Commission for selected customer has been charged for current month !", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to charge commission!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
