﻿using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using BusinessLayer.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer.Repos;

namespace Ajoor
{
    public partial class SuperAdminMonthlyView : Form
    {
        TransactionRepo _TransactionRepo = new TransactionRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SettingsRepo _SettingsRepo = new SettingsRepo();

        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iCount = 0;
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths    
        int customerID = 0;

        public SuperAdminMonthlyView()
        {
            InitializeComponent();
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (chkUseDate.Checked == true)
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
                    if (cmb_Subadmin.SelectedValue != null && cmb_Customers.SelectedValue != null)
                    {
                        if (!bgw_PullReport_DatesAndSubAdminAndCustomerOnly.IsBusy)
                        {
                            bgw_PullReport_DatesAndSubAdminAndCustomerOnly.RunWorkerAsync();
                        }
                        return;
                    }
                    if (cmb_Subadmin.SelectedValue != null)
                    {
                        if (!bgw_PullReport_DatesAndSubadminOnly.IsBusy)
                        {
                            bgw_PullReport_DatesAndSubadminOnly.RunWorkerAsync();
                        }
                        return;
                    }
                    else
                    {
                        if (!bgw_PullReport_DatesOnly.IsBusy)
                        {
                            bgw_PullReport_DatesOnly.RunWorkerAsync();
                        }
                        return;
                    }
                }
            }
            else
            {
                if (cmb_Customers.SelectedValue != null && cmb_Subadmin.SelectedValue != null)
                {
                    customerID = int.Parse(cmb_Customers.SelectedValue.ToString());
                    if (!bgw_PullReport_SubAdminAndCustomerOnly.IsBusy)
                    {
                        bgw_PullReport_SubAdminAndCustomerOnly.RunWorkerAsync();
                    }
                    return;
                }
                if (cmb_Subadmin.SelectedValue != null)
                {
                    if (!bgw_PullReport_SubAdminOnly.IsBusy)
                    {
                        bgw_PullReport_SubAdminOnly.RunWorkerAsync();
                    }
                    return;
                }
                if (cmb_Customers.SelectedValue != null)
                {
                    customerID = int.Parse(cmb_Customers.SelectedValue.ToString());
                    if (!bgw_PullReport_CustomerOnly.IsBusy)
                    {
                        bgw_PullReport_CustomerOnly.RunWorkerAsync();
                    }
                    return;
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
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
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
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullReport_SubAdminOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month).Sum(s => s.AmountContributed) != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month).Sum(s => s.AmountContributed) : 0,
                            TotalWithdrawals = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month).Sum(s => s.AmountCollected) != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month).Sum(s => s.AmountCollected) : 0,
                            Commission = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.TransactionType == "Commission Charge" && s.Commission > 0).FirstOrDefault() != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.TransactionType == "Commission Charge" && s.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.TransactionType == "Extra Commission Charge" && s.ExtraCommission > 0).FirstOrDefault() != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.TransactionType == "Extra Commission Charge" && s.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            //TotalSavings = g.Sum(s => s.AmountContributed),
                            //TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            //Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.TransactionType == "Commission Charge").Where(x => x.CreatedDate.Value.Month == DateTime.Now.Month && x.Commission > 0).FirstOrDefault() != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.CreatedDate.Value.Month == DateTime.Now.Month && x.Commission > 0).FirstOrDefault().Commission : 0,
                            //ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.TransactionType == "Extra Commission Charge").Where(x => x.CreatedDate.Value.Month == DateTime.Now.Month && x.ExtraCommission > 0).FirstOrDefault() != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.CreatedDate.Value.Month == DateTime.Now.Month && x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
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
            txt_TotalCommission.ReadOnly = true; txt_TotalExtraCommission.ReadOnly = true;
            txt_TotalDebt.ReadOnly = true; txt_TotalAmountPayable.ReadOnly = true;

            var settings = _SettingsRepo.GetConfig();
            var numberOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var dayInCurrentMonth = DateTime.Now.Day;
            var numberOfDaysToStartRemindingUser = int.Parse(settings.DaysToRemindForClosingMonth);
            var daysLeftInCurrentMonth = numberOfDaysInCurrentMonth - dayInCurrentMonth;
            var numberOfDaysAllowedInFlexibleMode = int.Parse(settings.DaysToAllowForFlexibleClosingOfMonth);
            var daysLeftInFlexibleMode = numberOfDaysAllowedInFlexibleMode - dayInCurrentMonth;
            if (daysLeftInCurrentMonth == 0)
            {
                if (_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month))
                {
                    btn_EndMonth.Enabled = false;
                }
                else
                {
                    btn_EndMonth.Enabled = true;
                }
            }

            if (dayInCurrentMonth <= numberOfDaysAllowedInFlexibleMode)
            {
                if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
                {
                    btn_EndMonthFlexibleMode.Enabled = true;
                }
                else
                {
                    btn_EndMonthFlexibleMode.Enabled = false;
                }
            }

            Cursor.Current = Cursors.WaitCursor;
            if (!bgw_SubAdmin.IsBusy)
            {
                bgw_SubAdmin.RunWorkerAsync();
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
            cmb_Customers.Invoke(new MethodInvoker(delegate
            {
                cmb_Customers.DataSource = _CustomerRepo.GetAllRecords().Select(x => new { x.CustomerId, x.CustomerCredentials }).ToList();
                cmb_Customers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb_Customers.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmb_Customers.DisplayMember = "CustomerCredentials";
                cmb_Customers.ValueMember = "CustomerID";
                cmb_Customers.SelectedIndex = -1;
            }));
            Cursor.Current = Cursors.Default;
            e.Result = "Done";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv_SummaryMonthlyView.RowCount > 0)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printSummary;
                printDialog.UseEXDialog = true;
                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    //printSummary.DocumentName = $"Monthly Summary {DateTime.Now}";
                    printSummary.Print();
                }
            }
            else
            {
                MessageBox.Show($"No data to print.", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printSummary_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                //iCellHeight = 0;
                //iCount = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgv_SummaryMonthlyView.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printSummary_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgv_SummaryMonthlyView.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor(GridCol.Width /
                            (double)iTotalWidth * iTotalWidth *
                            ((double)e.MarginBounds.Width / iTotalWidth)));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgv_SummaryMonthlyView.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgv_SummaryMonthlyView.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Monthly Summary",
                                new Font(dgv_SummaryMonthlyView.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Monthly Summary",
                                new Font(dgv_SummaryMonthlyView.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dgv_SummaryMonthlyView.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dgv_SummaryMonthlyView.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Monthly Summary",
                                new Font(new Font(dgv_SummaryMonthlyView.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgv_SummaryMonthlyView.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
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
                DateTime previousDate = DateTime.Now.AddMonths(-1);
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            EndOfMonthBalance = g.Where(s => s.CreatedDate.Value.Month == previousDate.Month && s.CreatedDate.Value.Year == previousDate.Year && s.TransactionType == "End Of Month").FirstOrDefault() != null ? g.Where(s => s.CreatedDate.Value.Month == previousDate.Month && s.CreatedDate.Value.Year == previousDate.Year && s.TransactionType == "End Of Month").FirstOrDefault().EOMBalance : 0,
                            TotalSavings = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year).Sum(s => s.AmountContributed) != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year).Sum(s => s.AmountContributed) : 0,
                            TotalWithdrawals = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year).Sum(s => s.AmountCollected) != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year).Sum(s => s.AmountCollected) : 0,
                            Commission = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year && s.TransactionType == "Commission Charge" && s.Commission > 0).FirstOrDefault() != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year && s.TransactionType == "Commission Charge" && s.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year && s.TransactionType == "Extra Commission Charge" && s.ExtraCommission > 0).FirstOrDefault() != null ? g.Where(s => s.CreatedDate.Value.Month == DateTime.Now.Month && s.CreatedDate.Value.Year == DateTime.Now.Year && s.TransactionType == "Extra Commission Charge" && s.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable : 0,
                            TotalDebit = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt : 0,
                            //TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            //TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).Where(x => x.TransactionType != "End Of Month").FirstOrDefault().TotalDebt,
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
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[7].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[7].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[8].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[8].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalDebt.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_SummaryMonthlyView.SelectedRows.Count > 0)
                {
                    if (dgv_SummaryMonthlyView.SelectedRows.Count > 1)
                    {
                        MessageBox.Show("Please edit customers one at a time!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        long customerId = long.Parse(dgv_SummaryMonthlyView.SelectedRows[0].Cells[1].Value.ToString());
                        if (customerId > 0)
                        {
                            ViewCustomerTransactions viewCustomerTransactions_Form = new ViewCustomerTransactions(customerId);
                            viewCustomerTransactions_Form.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to view transactions!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullReport_CustomerOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == customerID).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullReport_SubAdminAndCustomerOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.CreatedBy == cmb_Subadmin.SelectedValue.ToString() && x.CustomerId == customerID).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_PullReport_DatesAndSubAdminAndCustomerOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString() && x.CustomerId == customerID).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_DatesAndCustomerOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_SummaryMonthlyView.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_SummaryMonthlyView.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CustomerId == customerID).GroupBy(p => p.CustomerId).Select(g => new
                        {
                            Name = g.FirstOrDefault().CustomerName,
                            AccountNumber = g.FirstOrDefault().AccountNumber,
                            TotalSavings = g.Sum(s => s.AmountContributed),
                            TotalWithdrawals = g.Sum(s => s.AmountCollected),
                            Commission = g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.Commission > 0).FirstOrDefault().Commission : 0,
                            ExtraCommission = g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission != null ? g.OrderByDescending(s => s.TransactionId).Where(x => x.ExtraCommission > 0).FirstOrDefault().ExtraCommission : 0,
                            TotalCredit = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) : 0,
                            TotalDebt = g.Sum(s => s.AmountContributed) - (g.Sum(s => s.AmountCollected) + g.Sum(s => s.Commission) + g.Sum(s => s.ExtraCommission)) > 0 ? 0 : g.OrderByDescending(x => x.TransactionId).FirstOrDefault().TotalDebt,
                            CreatedBy = g.FirstOrDefault().CreatedBy,
                            CreatedDate = g.FirstOrDefault().CreatedDate
                        }).ToList();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[3].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[3].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[2].Value.ToString();
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
                            if (dgv_SummaryMonthlyView.Rows[i].Cells[4].Value != null)
                            {
                                string total = dgv_SummaryMonthlyView.Rows[i].Cells[4].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }));
                txt_TotalExtraCommission.Invoke(new MethodInvoker(delegate
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
                        txt_TotalExtraCommission.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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
                Cursor.Current = Cursors.Default;
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_EndMonth_Click(object sender, EventArgs e)
        {
            try
            {
                var presentMonth = DateTime.Now.Month;
                var monthName = Utilities.GetMonthName(presentMonth);
                if (!_TransactionRepo.HasMonthBeenClosed(presentMonth))
                {
                    switch (MessageBox.Show($"You are about to close the month of {monthName}. \n\nThis operation might take several minutes. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            Cursor.Current = Cursors.WaitCursor;
                            if (_TransactionRepo.CloseMonthOperation())
                            {
                                MessageBox.Show($"The month of {monthName} has been closed successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btn_EndMonth.Enabled = false;
                                if (!bgw_PullData.IsBusy)
                                {
                                    bgw_PullData.RunWorkerAsync();
                                }
                            }
                            Cursor.Current = Cursors.Default;
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
                else
                {
                    MessageBox.Show($"The month of {monthName} has been closed already!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseMonthOperation(string monthName)
        {
            var records = _TransactionRepo.GetAllTransactions().GroupBy(p => p.CustomerId).Select(g => new
            {
                CustomerID = g.FirstOrDefault().CustomerId,
                TotalCredit = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable : 0,
                TotalDebt = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt : 0,
            }).ToList();
            List<EndOfMonthTransactions> eomTransactions = new List<EndOfMonthTransactions>();
            foreach (var record in records)
            {
                EndOfMonthTransactions transaction = new EndOfMonthTransactions()
                {
                    CustomerId = record.CustomerID,
                    AmountContributed = 0m,
                    AmountCollected = 0m,
                    TransactionType = "End Of Month",
                    Date = DateTime.Now,
                    Commission = 0m,
                    ExtraCommission = 0m,
                    AmountPayable = 0m,
                    Debt = 0m,
                    TotalDebt = 0m,
                    EOMBalance = record.TotalCredit == 0 ? -1 * record.TotalDebt : record.TotalCredit,
                    CreatedBy = Utilities.USERNAME,
                    CreatedDate = DateTime.Now
                };
                if (transaction.EOMBalance.ToString().Contains("-"))
                {
                    transaction.TotalDebt = transaction.EOMBalance * -1;
                }
                else
                {
                    transaction.AmountPayable = transaction.EOMBalance;
                }
                eomTransactions.Add(transaction);
            }
            if (_TransactionRepo.EndOfMonthTransaction(eomTransactions))
            {
                MessageBox.Show($"The month of {monthName} has been closed successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!bgw_PullData.IsBusy)
                {
                    bgw_PullData.RunWorkerAsync();
                }
            }
        }

        private void btn_EndMonthFlexibleMode_Click(object sender, EventArgs e)
        {
            try
            {
                var previousMonth = DateTime.Now.Month - 1;
                var monthName = Utilities.GetMonthName(previousMonth);
                if (!_TransactionRepo.HasMonthBeenClosed(previousMonth))
                {
                    switch (MessageBox.Show($"You are about to close the previous month of {monthName}. \n\nThis operation might take several minutes. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            Cursor.Current = Cursors.WaitCursor;
                            if (_TransactionRepo.ClosePreviousMonthOperation())
                            {
                                MessageBox.Show($"The previous month of {monthName} has been closed successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btn_EndMonthFlexibleMode.Enabled = false;
                                if (!bgw_PullData.IsBusy)
                                {
                                    bgw_PullData.RunWorkerAsync();
                                }
                            }
                            Cursor.Current = Cursors.Default;
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
                else
                {
                    MessageBox.Show($"The previous month of {monthName} has been closed already!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
