using Ajoor.Core;
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
    public partial class SuperAdminCreditCustomer : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        static long selectedID = 0;
        public SuperAdminCreditCustomer()
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
                dgv_CustomerTransactions.DataSource = _TransactionRepo.GetCreditTransactions().Where(x => x.CustomerId == selectedID && x.CreatedBy == Utilities.USERNAME).Select(g => new
                {
                    TransactionId = g.TransactionId,
                    CustomerId = g.CustomerId,
                    CustomerName = g.CustomerName,
                    TransactionType = g.TransactionType,
                    AmountContributed = g.AmountContributed,
                    Date = g.Date,
                    AmountPayable = g.AmountPayable,
                    CreatedBy = g.CreatedBy,
                    CreatedDate = g.CreatedDate
                }).ToList();
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
            catch (Exception ex)
            { }
        }

        private void CreditCustomer_Load(object sender, EventArgs e)
        {
            txt_AccountNumber.ReadOnly = true; txt_Commission.ReadOnly = true;
            txt_TotalDebt.ReadOnly = true;
            if (!bgwGetCustomers.IsBusy)
            {
                bgwGetCustomers.RunWorkerAsync();
            }
        }

        private void btn_Credit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Customers.SelectedValue != null)
                {
                    if (txt_AmountContributed.Text != string.Empty)
                    {
                        var money = Utilities.CurrencyFormat(txt_AmountContributed.Text);
                        txt_AmountContributed.Text = Utilities.RemoveCommasAndDots(txt_AmountContributed.Text);
                        var customer = _CustomerRepo.GetCustomer(int.Parse(cmb_Customers.SelectedValue.ToString()));
                        var customerTransaction = _TransactionRepo.GetAllTransactions()
                          .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                        Transactions transactions = new Transactions()
                        {
                            CustomerId = int.Parse(cmb_Customers.SelectedValue.ToString()),
                            AmountContributed = decimal.Parse(txt_AmountContributed.Text),
                            AmountCollected = 0m,
                            TransactionType = "Credit",
                            TotalDebt = customerTransaction != null ? customerTransaction.TotalDebt.HasValue ? decimal.Parse(txt_AmountContributed.Text) < customerTransaction.TotalDebt ? customerTransaction.TotalDebt - decimal.Parse(txt_AmountContributed.Text) : 0m : customerTransaction.TotalDebt : 0m,
                            Date = DateTime.Now,
                            Commission = 0m,
                            AmountPayable = customerTransaction != null ? customerTransaction.TotalDebt.HasValue ? decimal.Parse(txt_AmountContributed.Text) >= customerTransaction.TotalDebt ? decimal.Parse(txt_AmountContributed.Text) - customerTransaction.TotalDebt : 0m : decimal.Parse(txt_AmountContributed.Text) : decimal.Parse(txt_AmountContributed.Text),
                            CreatedBy = Utilities.USERNAME,
                            CreatedDate = DateTime.Now
                        };
                        if (_TransactionRepo.CreditTransaction(transactions))
                        {
                            MessageBox.Show("Customer credited successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var totalDebt = _TransactionRepo.GetAllTransactions()
                               .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault().TotalDebt.ToString();
                            txt_TotalDebt.Text = Utilities.CurrencyFormat(totalDebt);
                            if (!bgwGetRecords.IsBusy)
                            {
                                bgwGetRecords.RunWorkerAsync();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter an amount", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_AmountContributed.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to credit!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreditCustomer_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txt_AmountContributed_Leave(object sender, EventArgs e)
        {
            txt_AmountContributed.Text = Utilities.CurrencyFormat(txt_AmountContributed.Text);
        }

        private void txt_AmountContributed_Enter(object sender, EventArgs e)
        {
            txt_AmountContributed.Text = Utilities.RemoveCommasAndDots(txt_AmountContributed.Text);
        }

        private void txt_AmountContributed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Credit_Click(this, new EventArgs());
            }
        }
    }
}
