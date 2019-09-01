using Ajoor.BusinessLayer.DTO;
using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class DebitCustomer : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        static long selectedID = 0;
        public DebitCustomer()
        {
            InitializeComponent();
        }

        private void bgwGetCustomers_DoWork(object sender, DoWorkEventArgs e)
        {
            cmb_Customers.Invoke(new MethodInvoker(delegate
            {
                cmb_Customers.DataSource = _CustomerRepo.GetAllRecords().Where(x => x.CreatedBy == Utilities.USERNAME).Select(x => new { x.CustomerId, x.CustomerCredentials }).ToList();
                cmb_Customers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb_Customers.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb_Customers.DisplayMember = "CustomerCredentials";
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
                txt_TotalCredit.Text = Utilities.CurrencyFormat(customerTransaction != null ? customerTransaction.AmountPayable.ToString() : 0m.ToString());
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
            txt_TotalDebt.ReadOnly = true; txt_TotalCredit.ReadOnly = true;
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
                                    ExtraCommission = 0m,
                                    AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                    CreatedBy = Utilities.USERNAME,
                                    CreatedDate = DateTime.Now
                                };
                                if (_TransactionRepo.DebitTransaction(transactions))
                                {
                                    MessageBox.Show("Customer debited successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var totalDebt = _TransactionRepo.GetAllTransactions()
                                           .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                                    var totalCredit = _TransactionRepo.GetAllTransactions()
                                        .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().AmountPayable.ToString();
                                    txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt); txt_TotalCredit.Text = Utilities.CurrencyFormat(totalCredit);
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
                                switch (MessageBox.Show($"You are about to loan {debtMoney} to {customer.FullName}. \n\nDo you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
                                            ExtraCommission = 0m,
                                            AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                            Debt = debt,
                                            TotalDebt = customerTransaction.TotalDebt.HasValue ? customerTransaction.TotalDebt + debt : debt,
                                            CreatedBy = Utilities.USERNAME,
                                            CreatedDate = DateTime.Now
                                        };
                                        if (_TransactionRepo.DebitTransaction(transactions))
                                        {
                                            MessageBox.Show($"Customer has been loaned the sum of {debtMoney} successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            var totalDebt = _TransactionRepo.GetAllTransactions()
                                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                                            var totalCredit = _TransactionRepo.GetAllTransactions()
                                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().AmountPayable.ToString();
                                            txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt); txt_TotalCredit.Text = Utilities.CurrencyFormat(totalCredit);
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
                            switch (MessageBox.Show($"You are about to loan {debtMoney} to {customer.FullName}. \n\nDo you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
                                        ExtraCommission = 0m,
                                        AmountPayable = decimal.Parse(txt_AmountCollected.Text),
                                        Debt = debt,
                                        TotalDebt = customerTransaction != null ? customerTransaction.TotalDebt + debt : debt,
                                        CreatedBy = Utilities.USERNAME,
                                        CreatedDate = DateTime.Now
                                    };
                                    if (_TransactionRepo.DebitTransaction(transactions))
                                    {
                                        MessageBox.Show($"Customer has been loaned the sum of {debtMoney} successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        var totalDebt = _TransactionRepo.GetAllTransactions()
                                            .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                                        var totalCredit = _TransactionRepo.GetAllTransactions()
                                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().AmountPayable.ToString();
                                        txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt); txt_TotalCredit.Text = Utilities.CurrencyFormat(totalCredit);
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
            if (e.KeyCode == Keys.Enter)
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
                    var transactionRecord = _TransactionRepo.GetDebitTransactions().Where(x => x.CustomerId == customerId).OrderByDescending(p => p.TransactionId).FirstOrDefault();
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
                            ExtraCommission = 0m,
                            AmountPayable = 0m,
                            Debt = transactionRecord != null ? transactionRecord.Debt : customer.Commission,
                            TotalDebt = transactionRecord != null ? transactionRecord.TotalDebt + customer.Commission : customer.Commission,
                            CreatedBy = Utilities.USERNAME,
                            CreatedDate = DateTime.Now
                        };
                        if (_TransactionRepo.DebitTransaction(transactions))
                        {
                            MessageBox.Show($"Commission has been charged successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var totalDebt = _TransactionRepo.GetAllTransactions()
                                               .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                            var totalCredit = _TransactionRepo.GetAllTransactions()
                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().AmountPayable.ToString();
                            txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt); txt_TotalCredit.Text = Utilities.CurrencyFormat(totalCredit);
                            if (!bgwGetRecords.IsBusy)
                            {
                                bgwGetRecords.RunWorkerAsync();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Commission for selected customer has been charged for current month!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to charge commission!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_ExtraCommision_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Customers.SelectedValue != null)
                {
                    var customerId = int.Parse(cmb_Customers.SelectedValue.ToString());
                    var customer = _CustomerRepo.GetCustomer(customerId);
                    var extraCommission = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == customerId && x.ExtraCommission == customer.Commission && x.Date.Value.Month == DateTime.Now.Month).FirstOrDefault();
                    var transactionRecord = _TransactionRepo.GetDebitTransactions().Where(x => x.CustomerId == customerId).OrderByDescending(p => p.TransactionId).FirstOrDefault();
                    if (extraCommission == null)
                    {
                        Transactions transactions = new Transactions()
                        {
                            CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                            AmountContributed = 0m,
                            AmountCollected = 0m,
                            TransactionType = "Extra Commission Charge",
                            Date = DateTime.Now,
                            Commission = 0m,
                            ExtraCommission = customer.Commission,
                            AmountPayable = 0m,
                            Debt = transactionRecord != null ? transactionRecord.Debt : customer.Commission,
                            TotalDebt = transactionRecord != null ? transactionRecord.TotalDebt + customer.Commission : customer.Commission,
                            CreatedBy = Utilities.USERNAME,
                            CreatedDate = DateTime.Now
                        };
                        if (_TransactionRepo.DebitTransaction(transactions))
                        {
                            MessageBox.Show($"Extra Commission has been charged successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var totalDebt = _TransactionRepo.GetAllTransactions()
                                               .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                            var totalCredit = _TransactionRepo.GetAllTransactions()
                                .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().AmountPayable.ToString();
                            txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt); txt_TotalCredit.Text = Utilities.CurrencyFormat(totalCredit);
                            if (!bgwGetRecords.IsBusy)
                            {
                                bgwGetRecords.RunWorkerAsync();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Extra Commission for selected customer has been charged for current month!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to charge extra commission!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
