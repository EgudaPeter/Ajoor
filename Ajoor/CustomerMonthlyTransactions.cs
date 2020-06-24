using Ajoor.BusinessLayer.Core;
using Ajoor.BusinessLayer.Repos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class CustomerMonthlyTransactions : Form
    {
        TransactionRepo _TransactionRepo = new TransactionRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        long _customerId = 0;
        public CustomerMonthlyTransactions(long customerId)
        {
            InitializeComponent(); _customerId = customerId;
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

        private void CustomerMonthlyTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                var customer = _CustomerRepo.GetCustomer(_customerId);
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

        private void bgw_PullData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int currentMonth = DateTime.Now.Month; int currentYear = DateTime.Now.Year;
            lbMonthName.Invoke(new MethodInvoker(delegate { lbMonthName.Text = Utilities.GetMonthName(currentMonth); }));
            try
            {
                dgv_CustomerTransactionRecords.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_CustomerTransactionRecords.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == _customerId
                        && x.CreatedDate.Value.Month == currentMonth
                        && x.CreatedDate.Value.Year == currentYear).Select(x => new
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
    }
}
