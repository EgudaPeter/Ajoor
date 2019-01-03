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
    public partial class SuperAdminBalance : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        public SuperAdminBalance()
        {
            InitializeComponent();
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            if (dtp_Start.Value == null)
            {
                MessageBox.Show("Please you must specify a start date!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_Start.Focus();
                return;
            }
            if (dtp_End.Value == null)
            {
                MessageBox.Show("Please you must specify an end date!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_End.Focus();
                return;
            }
            if (dtp_Start.Value != null && dtp_End.Value != null)
            {
                if (cmb_Subadmin.SelectedValue != null)
                {
                    if (!bwg_PullReport_Received.IsBusy)
                    {
                        bwg_PullReport_Received.RunWorkerAsync();
                    }
                    if (!bwg_PullReports_Payment.IsBusy)
                    {
                        bwg_PullReports_Payment.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Please you must specify sub-admin!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_Subadmin.Focus();
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

        private void bwg_PullReport_Received_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Received.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Received.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).GroupBy(p => p.CreatedBy).Select(x => new
                        {
                            Name = x.FirstOrDefault().CreatedBy,
                            DailyContribution = x.Where(p => p.CreatedBy == x.FirstOrDefault().CreatedBy).Sum(f => f.AmountContributed),
                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_TotalRecordsReceived.Invoke(new MethodInvoker(delegate { lb_TotalRecordsReceived.Text = dgv_Received.RowCount.ToString(); }));

                txt_TotalBalanceReceived.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Received.RowCount; i++)
                        {
                            if (dgv_Received.Rows[i].Cells[1].Value != null)
                            {
                                string total = dgv_Received.Rows[i].Cells[1].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalBalanceReceived.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalReceived.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Received.RowCount; i++)
                        {
                            if (dgv_Received.Rows[i].Cells[1].Value != null)
                            {
                                string total = dgv_Received.Rows[i].Cells[1].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalReceived.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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

        private void bwg_PullReport_Payment_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Payment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Payment.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).GroupBy(p => p.CustomerId).Select(x => new
                        {
                            AccountNumber = x.FirstOrDefault().AccountNumber,
                            Name = x.FirstOrDefault().CustomerName,
                            Amount = x.Sum(f => f.AmountCollected),
                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_TotalRecordsPaid.Invoke(new MethodInvoker(delegate { lb_TotalRecordsPaid.Text = dgv_Payment.RowCount.ToString(); }));

                txt_TotalPayment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Payment.RowCount; i++)
                        {
                            if (dgv_Payment.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_Payment.Rows[i].Cells[2].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalPayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_PhysicalCash.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            txt_PhysicalCash.Text = Utilities.CurrencyFormat(0.ToString());
                        }
                        else
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalBalanceReceived.Text) - decimal.Parse(txt_TotalPayment.Text);
                            txt_PhysicalCash.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_Shortage.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalPayment.Text) - decimal.Parse(txt_TotalBalanceReceived.Text);
                            txt_Shortage.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                        else
                        {
                            txt_Shortage.Text = Utilities.CurrencyFormat(0.ToString());
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalBalancePayment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalPayment.Text) - decimal.Parse(txt_Shortage.Text);
                            txt_TotalBalancePayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                        else
                        {
                            decimal grandTotal = decimal.Parse(txt_PhysicalCash.Text) + decimal.Parse(txt_TotalPayment.Text);
                            txt_TotalBalancePayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
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

        private void SuperAdminBalance_Load(object sender, EventArgs e)
        {
            if (!bwg_SubAdmin.IsBusy)
            {
                bwg_SubAdmin.RunWorkerAsync();
            }
        }

        private void btn_PullRecordsForSuperAdmin_Click(object sender, EventArgs e)
        {
            if (!bgw_PullReportsForSuperAdmin_Received.IsBusy)
            {
                bgw_PullReportsForSuperAdmin_Received.RunWorkerAsync();
            }
            if (!bgw_PullReportsForSuperAdmin_Payment.IsBusy)
            {
                bgw_PullReportsForSuperAdmin_Payment.RunWorkerAsync();
            }
        }

        private void bgw_PullReportsForSuperAdmin_Received_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Received.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Received.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == Utilities.USERNAME).GroupBy(p => p.CreatedBy).Select(x => new
                        {
                            Name = x.FirstOrDefault().CreatedBy,
                            DailyContribution = x.Where(p => p.CreatedBy == x.FirstOrDefault().CreatedBy).Sum(f => f.AmountContributed),
                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_TotalRecordsReceived.Invoke(new MethodInvoker(delegate { lb_TotalRecordsReceived.Text = dgv_Received.RowCount.ToString(); }));

                txt_TotalBalanceReceived.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Received.RowCount; i++)
                        {
                            if (dgv_Received.Rows[i].Cells[1].Value != null)
                            {
                                string total = dgv_Received.Rows[i].Cells[1].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalBalanceReceived.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalReceived.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Received.RowCount; i++)
                        {
                            if (dgv_Received.Rows[i].Cells[1].Value != null)
                            {
                                string total = dgv_Received.Rows[i].Cells[1].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalReceived.Text = Utilities.CurrencyFormat(grandTotal.ToString());
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

        private void bgw_PullReportsForSuperAdmin_Payment_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Payment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Payment.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == Utilities.USERNAME).GroupBy(p => p.CustomerId).Select(x => new
                        {
                            AccountNumber = x.FirstOrDefault().AccountNumber,
                            Name = x.FirstOrDefault().CustomerName,
                            Amount = x.Sum(f => f.AmountCollected),

                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_TotalRecordsPaid.Invoke(new MethodInvoker(delegate { lb_TotalRecordsPaid.Text = dgv_Payment.RowCount.ToString(); }));

                txt_TotalPayment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        decimal grandTotal = 0m;
                        for (int i = 0; i < dgv_Payment.RowCount; i++)
                        {
                            if (dgv_Payment.Rows[i].Cells[2].Value != null)
                            {
                                string total = dgv_Payment.Rows[i].Cells[2].Value.ToString();
                                grandTotal += decimal.Parse(total);
                            }
                        }
                        txt_TotalPayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_PhysicalCash.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            txt_PhysicalCash.Text = Utilities.CurrencyFormat(0.ToString());
                        }
                        else
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalBalanceReceived.Text) - decimal.Parse(txt_TotalPayment.Text);
                            txt_PhysicalCash.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_Shortage.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalPayment.Text) - decimal.Parse(txt_TotalBalanceReceived.Text);
                            txt_Shortage.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                        else
                        {
                            txt_Shortage.Text = Utilities.CurrencyFormat(0.ToString());
                        }
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                txt_TotalBalancePayment.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        if (decimal.Parse(txt_TotalPayment.Text) > decimal.Parse(txt_TotalBalanceReceived.Text))
                        {
                            decimal grandTotal = decimal.Parse(txt_TotalPayment.Text) - decimal.Parse(txt_Shortage.Text);
                            txt_TotalBalancePayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
                        else
                        {
                            decimal grandTotal = decimal.Parse(txt_PhysicalCash.Text) + decimal.Parse(txt_TotalPayment.Text);
                            txt_TotalBalancePayment.Text = Utilities.CurrencyFormat(grandTotal.ToString());
                        }
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
