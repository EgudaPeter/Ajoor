using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
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
    public partial class ViewCustomerTransactions : Form
    {
        TransactionRepo _TransactionRepo = new TransactionRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        long _customerAcctNumber = 0;
        long _customerId = 0;
        public ViewCustomerTransactions(long customerAcctNumber)
        {
            InitializeComponent(); _customerAcctNumber = customerAcctNumber;
        }

        private void ViewCustomerTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                var customer = _CustomerRepo.GetCustomerWithAccountNumber(_customerAcctNumber);
                _customerId = customer.CustomerId;
                lbCustomerName.Text = customer.FullName;
                if (!bgw_PullData.IsBusy)
                {
                    bgw_PullData.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_CustomerTransactionRecords.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_CustomerTransactionRecords.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == _customerId).Select(x => new
                        {
                            CustomerName = x.CustomerName,
                            AccountNumber = x.AccountNumber,
                            TransactionType = x.TransactionType,
                            AmountContributed = x.AmountContributed,
                            AmountCollected = x.AmountCollected,
                            Total = x.AmountContributed - x.AmountCollected,
                            Date = x.Date,
                            CapturedBy = x.CreatedBy
                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerTransactionRecords.RowCount.ToString(); }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
