using Ajoor.Core;
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
    public partial class SuperAdminMonthlyView : Form
    {
        TransactionRepo _TransactionRepo = new TransactionRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public SuperAdminMonthlyView()
        {
            InitializeComponent();
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
                if (cmb_Subadmin.SelectedValue != null)
                {
                    if (!bwg_PullReport_DatesAndSubadminOnly.IsBusy)
                    {
                        bwg_PullReport_DatesAndSubadminOnly.RunWorkerAsync();
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

        private void bgw_PullReport_DatesOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            TransactionId = g.FirstOrDefault().TransactionId,
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            AmountContributed = g.Sum(s => s.AmountContributed),
                            AmountCollected = g.Sum(s => s.AmountCollected),
                            Commission = g.Sum(s => s.Commission),
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();

                        //dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value.Year >= dtp_Start.Value.Year && x.Date.Value.Month >= dtp_Start.Value.Month
                        // && x.Date.Value.Day >= dtp_Start.Value.Day && x.Date.Value.Year <= dtp_End.Value.Year && x.Date.Value.Month <= dtp_End.Value.Month
                        // && x.Date.Value.Day <= dtp_End.Value.Day).GroupBy(p => p.CustomerId).Select(g => new
                        // {
                        //     TransactionId = g.FirstOrDefault().TransactionId,
                        //     Name = g.FirstOrDefault().CustomerName,
                        //     AccountNumber = g.FirstOrDefault().AccountNumber,
                        //     AmountContributed = g.Sum(s => s.AmountContributed),
                        //     AmountCollected = g.Sum(s => s.AmountCollected),
                        //     Commission = g.Sum(s => s.Commission),
                        //     AmountPayable = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) : 0,
                        //     TotalDebt = g.Sum(s => s.TotalDebt) > 0 ? g.Sum(s => s.TotalDebt) + g.Sum(s => s.Commission) : g.Sum(s => s.TotalDebt),
                        //     CreatedBy = g.FirstOrDefault().CreatedBy,
                        //     CreatedDate = g.FirstOrDefault().CreatedDate
                        // }).ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_SummaryMonthlyView.RowCount.ToString(); }));

                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
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
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalCommission.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalAmountPayable.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[6].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[6].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalAmountPayable.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalDebt.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[7].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[7].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebt.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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

        private void bgw_PullReport_DatesAndSubadminOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            TransactionId = g.FirstOrDefault().TransactionId,
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            AmountContributed = g.Sum(s => s.AmountContributed),
                            AmountCollected = g.Sum(s => s.AmountCollected),
                            Commission = g.Sum(s => s.Commission),
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();

                        //dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value.Year >= dtp_Start.Value.Year && x.Date.Value.Month >= dtp_Start.Value.Month
                        // && x.Date.Value.Day >= dtp_Start.Value.Day && x.Date.Value.Year <= dtp_End.Value.Year && x.Date.Value.Month <= dtp_End.Value.Month
                        // && x.Date.Value.Day <= dtp_End.Value.Day && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).GroupBy(p => p.CustomerId).Select(g => new
                        // {
                        //     TransactionId = g.FirstOrDefault().TransactionId,
                        //     Name = g.FirstOrDefault().CustomerName,
                        //     AccountNumber = g.FirstOrDefault().AccountNumber,
                        //     AmountContributed = g.Sum(s => s.AmountContributed),
                        //     AmountCollected = g.Sum(s => s.AmountCollected),
                        //     Commission = g.Sum(s => s.Commission),
                        //     AmountPayable = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) : 0,
                        //     TotalDebt = g.Sum(s => s.TotalDebt) > 0 ? g.Sum(s => s.TotalDebt) + g.Sum(s => s.Commission) : g.Sum(s => s.TotalDebt),
                        //     CreatedBy = g.FirstOrDefault().CreatedBy,
                        //     CreatedDate = g.FirstOrDefault().CreatedDate
                        // }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_SummaryMonthlyView.RowCount.ToString(); }));

                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
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
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalCommission.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalAmountPayable.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[6].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[6].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalAmountPayable.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalDebt.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[7].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[7].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebt.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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

        private void SuperAdminMonthlyView_Load(object sender, EventArgs e)
        {
            txt_TotalCredit.ReadOnly = true; txt_TotalDebit.ReadOnly = true;
            txt_TotalCommission.ReadOnly = true; txt_TotalAmountPayable.ReadOnly = true;
            txt_TotalDebt.ReadOnly = true;
            if (!bwg_SubAdmin.IsBusy)
            {
                bwg_SubAdmin.RunWorkerAsync();
            }
            if (!bgw_PullData.IsBusy)
            {
                bgw_PullData.RunWorkerAsync();
            }
        }

        private void bwg_SubAdmin_DoWork(object sender, DoWorkEventArgs e)
        {
            cmb_Subadmin.Invoke(new MethodInvoker(delegate
            {
                cmb_Subadmin.DataSource = _SubAdminRepo.GetAllRecords().Select(x => new { x.SubId, x.Lastname, x.Firstname, x.Username, x.FullName }).ToList();
                cmb_Subadmin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb_Subadmin.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb_Subadmin.DisplayMember = "FullName";
                cmb_Subadmin.ValueMember = "Username";
                cmb_Subadmin.SelectedIndex = -1;
            }));
            e.Result = "Done";
        }

        private void printSummary_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dgv_SummaryMonthlyView.Width, dgv_SummaryMonthlyView.Height);
            dgv_SummaryMonthlyView.DrawToBitmap(bm, new Rectangle(0, 0, dgv_SummaryMonthlyView.Width, dgv_SummaryMonthlyView.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printSummary.Print();
        }

        private void bgw_PullData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().GroupBy(p => p.CustomerId).Select(g => new
                        {
                            TransactionId = g.FirstOrDefault().TransactionId,
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            AmountContributed = g.Sum(s => s.AmountContributed),
                            AmountCollected = g.Sum(s => s.AmountCollected),
                            Commission = g.Sum(s => s.Commission),
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission)) > 0 ? 0 : g.OrderByDescending(x=>x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_SummaryMonthlyView.RowCount.ToString(); }));

                txt_TotalDebit.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
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
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCredit.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalCommission.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[5].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[5].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalAmountPayable.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[6].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[6].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalAmountPayable.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalDebt.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_SummaryMonthlyView.RowCount; i++)
                        {
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[7].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[7].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebt.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
