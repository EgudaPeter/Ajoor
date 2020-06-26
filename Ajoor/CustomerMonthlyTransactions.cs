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
        long _customerId = 0; string customerName = string.Empty;
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
                Cursor.Current = Cursors.WaitCursor;
                txt_TotalDebit.ReadOnly = true; txt_TotalCredit.ReadOnly = true; txt_TotalDifference.ReadOnly = true;
                var customer = _CustomerRepo.GetCustomer(_customerId);
                customerName = customer.FullName;
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
            cmbMonths.Invoke(new MethodInvoker(delegate
            {
                cmbMonths.DataSource = Utilities.GetAllMonthsInAYear().Select(x => new { x.Id, x.Name }).ToList();
                cmbMonths.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbMonths.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbMonths.DisplayMember = "Name";
                cmbMonths.ValueMember = "Id";
                cmbMonths.SelectedIndex = -1;
            }));
            cmbYears.Invoke(new MethodInvoker(delegate
            {
                cmbYears.DataSource = Utilities.GetValidYears();
                cmbYears.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbYears.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbYears.SelectedIndex = -1;
            }));
            int currentMonth = DateTime.Now.Month; int currentYear = DateTime.Now.Year;
            lbMonthName.Invoke(new MethodInvoker(delegate { lbMonthName.Text = $"Customer activity for the period of {Utilities.GetMonthName(currentMonth)}, {currentYear} for customer: {customerName}"; }));
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
                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalCredit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalDifference.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDifference.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwFilterRecords_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int selectedMonth = 0; int selectedYear = 0;
            cmbMonths.Invoke(new MethodInvoker(delegate { selectedMonth = cmbMonths.SelectedValue == null ? 0 : (int)cmbMonths.SelectedValue; }));
            cmbYears.Invoke(new MethodInvoker(delegate { selectedYear = cmbYears.SelectedValue == null ? 0 : (int)cmbYears.SelectedValue; }));
            try
            {
                if (selectedMonth > 0 && selectedYear > 0)
                {
                    lbMonthName.Invoke(new MethodInvoker(delegate { lbMonthName.Text = $"Customer activity for the period of {Utilities.GetMonthName(selectedMonth)}, {selectedYear} for customer: {customerName}"; }));
                    getRecords(selectedMonth, selectedYear);
                }
                else if (selectedMonth > 0)
                {
                    lbMonthName.Invoke(new MethodInvoker(delegate { lbMonthName.Text = $"Customer activity for the period of {Utilities.GetMonthName(selectedMonth)}, {2020} for customer: {customerName}"; }));
                    getRecords(selectedMonth, 2020);
                }
                else if (selectedYear > 0)
                {
                    lbMonthName.Invoke(new MethodInvoker(delegate { lbMonthName.Text = $"Customer activity for the period of year, {selectedYear} for customer: {customerName}"; }));
                    getRecords(0, selectedYear);
                }
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerTransactionRecords.RowCount.ToString(); }));
                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalCredit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalDifference.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_CustomerTransactionRecords.RowCount; i++)
                        {
                            if (dgv_CustomerTransactionRecords.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_CustomerTransactionRecords.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDifference.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getRecords(int month, int year)
        {
            try
            {
                if (month > 0)
                {
                    dgv_CustomerTransactionRecords.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            dgv_CustomerTransactionRecords.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == _customerId
                            && x.CreatedDate.Value.Month == month
                            && x.CreatedDate.Value.Year == year).Select(x => new
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
                }
                else
                {
                    dgv_CustomerTransactionRecords.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            dgv_CustomerTransactionRecords.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == _customerId
                            && x.CreatedDate.Value.Year == year).Select(x => new
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!bgwFilterRecords.IsBusy)
            {
                bgwFilterRecords.RunWorkerAsync();
            }
        }
    }
}
