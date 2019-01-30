using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class SummarySubAdminView : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        public SummarySubAdminView()
        {
            InitializeComponent();
        }

        private void bwg_Summary_DoWork(object sender, DoWorkEventArgs e)
        {
            cmb_Customers.Invoke(new MethodInvoker(delegate
            {
                cmb_Customers.DataSource = _CustomerRepo.GetAllRecords().Where(x=>x.CreatedBy == Utilities.USERNAME).Select(x => new { x.CustomerId, x.LastName, x.FirstName, x.AccountNumber, x.FullName }).ToList();
                cmb_Customers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb_Customers.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb_Customers.DisplayMember = "FullName";
                cmb_Customers.ValueMember = "CustomerId";
                cmb_Customers.SelectedIndex = -1;
            }));
            e.Result = "Done";
        }

        private void SummarySubAdminView_Load(object sender, EventArgs e)
        {
            txt_TotalCredit.ReadOnly = true; txt_TotalDebit.ReadOnly = true;
            txt_TotalCombined.ReadOnly = true;
            if (!bwg_Summary.IsBusy)
            {
                bwg_Summary.RunWorkerAsync();
            }
        }

        private void printSummary_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dgv_Summary.Width, dgv_Summary.Height);
            dgv_Summary.DrawToBitmap(bm, new Rectangle(0, 0, dgv_Summary.Width, dgv_Summary.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printSummary.Print();
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            if (dtp_Start.Value == null)
            {
                MessageBox.Show("Please you must specicy a start date!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_Start.Focus();
                return;
            }
            if (dtp_End.Value == null)
            {
                MessageBox.Show("Please you must specicy an end date!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_End.Focus();
                return;
            }
            if (dtp_Start.Value != null && dtp_End.Value != null)
            {
                if (cmb_Customers.SelectedValue != null)
                {
                    if (!bwg_PullReport_DatesAndCustomerOnly.IsBusy)
                    {
                        bwg_PullReport_DatesAndCustomerOnly.RunWorkerAsync();
                    }
                }
                else
                {
                    if (!bgw_PullReport_DatesOnly.IsBusy)
                    {
                        bgw_PullReport_DatesOnly.RunWorkerAsync();
                    }
                }
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //if (dgv_Summary.SelectedRows.Count > 0)
            //{
            //    if (dgv_Summary.SelectedRows.Count > 1)
            //    {
            //        MessageBox.Show("Please edit customer transactions one at a time!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        long ID = long.Parse(dgv_Summary.SelectedRows[0].Cells[0].Value.ToString());
            //        var record = _TransactionRepo.GetTransaction(ID);
            //        if (record != null)
            //        {
            //            if(record.TransactionType == "Credit")
            //            {
            //                EditCreditTransaction editCreditTransaction_Form = new EditCreditTransaction(record);
            //                if (editCreditTransaction_Form.ShowDialog() != DialogResult.Yes)
            //                {
            //                    if (cmb_Customers.SelectedValue != null && cmb_Subadmin.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_Dates_Customer_Subadmin_Only.IsBusy)
            //                        {
            //                            bwg_PullReport_Dates_Customer_Subadmin_Only.RunWorkerAsync();
            //                        }
            //                    }
            //                    else if (cmb_Customers.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_DatesAndCustomerOnly.IsBusy)
            //                        {
            //                            bwg_PullReport_DatesAndCustomerOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                    else if (cmb_Subadmin.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_DatesAndSubadminOnly.IsBusy)
            //                        {
            //                            bwg_PullReport_DatesAndSubadminOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (!bgw_PullReport_DatesOnly.IsBusy)
            //                        {
            //                            bgw_PullReport_DatesOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                EditCustomer editCustomer_Form = new EditCustomer(record);
            //                if (editCustomer_Form.ShowDialog() != DialogResult.Yes)
            //                {
            //                    if (cmb_Customers.SelectedValue != null && cmb_Subadmin.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_Dates_Customer_Subadmin_Only.IsBusy)
            //                        {
            //                            bwg_PullReport_Dates_Customer_Subadmin_Only.RunWorkerAsync();
            //                        }
            //                    }
            //                    else if (cmb_Customers.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_DatesAndCustomerOnly.IsBusy)
            //                        {
            //                            bwg_PullReport_DatesAndCustomerOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                    else if (cmb_Subadmin.SelectedValue != null)
            //                    {
            //                        if (!bwg_PullReport_DatesAndSubadminOnly.IsBusy)
            //                        {
            //                            bwg_PullReport_DatesAndSubadminOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (!bgw_PullReport_DatesOnly.IsBusy)
            //                        {
            //                            bgw_PullReport_DatesOnly.RunWorkerAsync();
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select atleast one customer transaction to edit!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
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

        private void SummarySubAdminView_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bgw_PullReport_DatesOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Summary.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date).Where(p => p.CreatedBy == Utilities.USERNAME)
                        .Select(x => new
                        {
                            CustomerName = x.CustomerName,
                            AccountNumber = x.AccountNumber,
                            TransactionType = x.TransactionType,
                            AmountContributed = x.AmountContributed,
                            AmountCollected = x.AmountCollected,
                            Total = x.AmountContributed - x.AmountCollected,
                            //Commission = x.Commission,
                            //AmountPayable = x.AmountPayable,
                            //Debt = x.Debt,
                            //TotalDebt = x.TotalDebt,
                            Date = x.Date,
                            CapturedBy = x.CreatedBy
                        }).ToList();

                        //    dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value.Year >= dtp_Start.Value.Year && x.Date.Value.Month >= dtp_Start.Value.Month
                        //&& x.Date.Value.Day >= dtp_Start.Value.Day && x.Date.Value.Year <= dtp_End.Value.Year && x.Date.Value.Month <= dtp_End.Value.Month
                        //&& x.Date.Value.Day <= dtp_End.Value.Day).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_Summary.RowCount.ToString(); }));

                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[4].Value.ToString();
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
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalCombined.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCombined.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullReport_DatesAndCustomerOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                long ID = 0;

                cmb_Customers.Invoke(new MethodInvoker(delegate
                {
                    ID = long.Parse(cmb_Customers.SelectedValue.ToString());
                }));

                dgv_Summary.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        //dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value.Year >= dtp_Start.Value.Year && x.Date.Value.Month >= dtp_Start.Value.Month
                        //&& x.Date.Value.Day >= dtp_Start.Value.Day && x.Date.Value.Year <= dtp_End.Value.Year && x.Date.Value.Month <= dtp_End.Value.Month
                        //&& x.Date.Value.Day <= dtp_End.Value.Day && x.CustomerId == ID).ToList();

                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CustomerId == ID).Where(p => p.CreatedBy == Utilities.USERNAME)
                        .Select(x => new
                        {
                            CustomerName = x.CustomerName,
                            AccountNumber = x.AccountNumber,
                            TransactionType = x.TransactionType,
                            AmountContributed = x.AmountContributed,
                            AmountCollected = x.AmountCollected,
                            Total = x.AmountContributed - x.AmountCollected,
                            //Commission = x.Commission,
                            //AmountPayable = x.AmountPayable,
                            //Debt = x.Debt,
                            //TotalDebt = x.TotalDebt,
                            Date = x.Date,
                            CapturedBy = x.CreatedBy
                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));

                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_Summary.RowCount.ToString(); }));

                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[4].Value.ToString();
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
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalCombined.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Summary.RowCount; i++)
                        {
                            if (dgv_Summary.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_Summary.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCombined.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));

                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
