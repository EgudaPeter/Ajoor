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
    public partial class EditCreditTransaction : Form
    {
        Transactions transaction = null;
        TransactionRepo _TransactionRepo = new TransactionRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        public EditCreditTransaction(Transactions model)
        {
            InitializeComponent(); transaction = model;
        }

        private void EditCreditTransaction_Load(object sender, EventArgs e)
        {
            txt_AccountNumber.Text = transaction.AccountNumber.ToString(); txt_AmountPayable.Text = transaction.AmountPayable.ToString();
            txt_CustomerName.Text = transaction.CustomerName; txt_TransactionType.Text = transaction.TransactionType;
            txt_Amount.Text = transaction.AmountContributed.ToString();
            txt_Amount.Text = Utilities.CurrencyFormat(transaction.AmountContributed.ToString());

            txt_AccountNumber.ReadOnly = true; txt_AmountPayable.ReadOnly = true;
            txt_CustomerName.ReadOnly = true; txt_TransactionType.ReadOnly = true;
            txt_Amount.Focus();
        }

        private void txt_Amount_Leave(object sender, EventArgs e)
        {
            txt_Amount.Text = Utilities.CurrencyFormat(txt_Amount.Text);
        }

        private void txt_Amount_Enter(object sender, EventArgs e)
        {
            txt_Amount.Text = Utilities.RemoveCommasAndDots(txt_Amount.Text);
        }

        private void txt_AmountKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
        //    if (txt_Amount.Text != string.Empty)
        //    {
        //        decimal? addDiff = 0m; decimal? subtractDiff = 0m;
        //        var money = Utilities.CurrencyFormat(txt_Amount.Text);
        //        txt_Amount.Text = Utilities.RemoveCommasAndDots(txt_Amount.Text);
        //        var customer = _CustomerRepo.GetCustomer(transaction.CustomerId);
        //        var customerTransaction = _TransactionRepo.GetAllTransactions()
        //          .OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
        //        if (transaction.AmountContributed >= decimal.Parse(txt_Amount.ToString()))
        //        {
        //            subtractDiff = transaction.AmountContributed - decimal.Parse(txt_Amount.ToString());
        //            Transactions transactions = new Transactions()
        //            {
        //                AmountContributed = decimal.Parse(txt_Amount.Text),
        //                TotalDebt = customerTransaction != null ? customerTransaction.TotalDebt.HasValue ? customerTransaction.TotalDebt.Value > 0 ?
        //                customerTransaction.TotalDebt + subtractDiff : subtractDiff >= customerTransaction.AmountPayable ? subtractDiff - customerTransaction.AmountPayable : 0m : subtractDiff >= customerTransaction.AmountPayable ? subtractDiff - customerTransaction.AmountPayable : 0m : 0m,
        //                AmountPayable = customerTransaction != null ? !customerTransaction.TotalDebt.HasValue || customerTransaction.TotalDebt.Value == 0 ? subtractDiff <= customerTransaction.AmountPayable ? customerTransaction.AmountPayable - subtractDiff : 0m : 0m : subtractDiff,
        //                UpdatedBy = Utilities.USERNAME,
        //                UpdatedDate = DateTime.Now
        //            };
        //            if (_TransactionRepo.UpdateCreditTransaction(transactions))
        //            {
        //                MessageBox.Show("Customer transaction edited successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        if (transaction.AmountContributed < decimal.Parse(txt_Amount.ToString()))
        //        {
        //            addDiff = decimal.Parse(txt_Amount.ToString()) - transaction.AmountContributed;
        //            Transactions transactions = new Transactions()
        //            {
        //                AmountContributed = decimal.Parse(txt_Amount.Text),
        //                TotalDebt = customerTransaction != null ? customerTransaction.TotalDebt.HasValue ? addDiff < customerTransaction.TotalDebt ? customerTransaction.TotalDebt - addDiff : 0m : customerTransaction.TotalDebt : 0m,
        //                AmountPayable = customerTransaction != null ? customerTransaction.TotalDebt.HasValue ? addDiff >= customerTransaction.TotalDebt ? addDiff - customerTransaction.TotalDebt : 0m : addDiff : addDiff,
        //                UpdatedBy = Utilities.USERNAME,
        //                UpdatedDate = DateTime.Now
        //            };
        //            if (_TransactionRepo.UpdateCreditTransaction(transactions))
        //            {
        //                MessageBox.Show("Customer transaction edited successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter an amount", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txt_Amount.Focus();
        //    }
        }
    }
}
