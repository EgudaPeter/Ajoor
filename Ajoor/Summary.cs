using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class Summary : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();

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
        public Summary()
        {
            InitializeComponent();
        }

        private void bwg_Summary_DoWork(object sender, DoWorkEventArgs e)
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

        private void Summary_Load(object sender, EventArgs e)
        {
            txt_TotalCredit.ReadOnly = true; txt_TotalDebit.ReadOnly = true;
            txt_TotalCombined.ReadOnly = true;
            if (!bwg_Summary.IsBusy)
            {
                bwg_Summary.RunWorkerAsync();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv_Summary.RowCount > 0)
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
                foreach (DataGridViewColumn dgvGridCol in dgv_Summary.Columns)
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
                    foreach (DataGridViewColumn GridCol in dgv_Summary.Columns)
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
                while (iRow <= dgv_Summary.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgv_Summary.Rows[iRow];
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
                            e.Graphics.DrawString("Summary",
                                new Font(dgv_Summary.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Summary",
                                new Font(dgv_Summary.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dgv_Summary.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dgv_Summary.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Summary",
                                new Font(new Font(dgv_Summary.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgv_Summary.Columns)
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
                if (cmb_Customers.SelectedValue != null && cmb_Subadmin.SelectedValue != null)
                {
                    if (!bwg_PullReport_Dates_Customer_Subadmin_Only.IsBusy)
                    {
                        bwg_PullReport_Dates_Customer_Subadmin_Only.RunWorkerAsync();
                    }
                }
                else if (cmb_Customers.SelectedValue != null)
                {
                    if (!bwg_PullReport_DatesAndCustomerOnly.IsBusy)
                    {
                        bwg_PullReport_DatesAndCustomerOnly.RunWorkerAsync();
                    }
                }
                else if (cmb_Subadmin.SelectedValue != null)
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

        private void Summary_FormClosing(object sender, FormClosingEventArgs e)
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
                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date)
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

        private void bgw_PullReport_DatesAndSubadminOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_Summary.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        //dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value.Year >= dtp_Start.Value.Year && x.Date.Value.Month >= dtp_Start.Value.Month
                        //&& x.Date.Value.Day >= dtp_Start.Value.Day && x.Date.Value.Year <= dtp_End.Value.Year && x.Date.Value.Month <= dtp_End.Value.Month
                        //&& x.Date.Value.Day <= dtp_End.Value.Day && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).ToList();

                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).Select(x => new
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

                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CustomerId == ID).Select(x => new
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

        private void bgw_PullReport_Dates_Customer_Subadmin_Only_DoWork(object sender, DoWorkEventArgs e)
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
                        //&& x.Date.Value.Day <= dtp_End.Value.Day && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString() && x.CustomerId == ID).ToList();

                        dgv_Summary.DataSource = _TransactionRepo.GetAllTransactions().Where(x => x.Date.Value >= dtp_Start.Value.Date && x.Date.Value <= dtp_End.Value.Date && x.CreatedBy == cmb_Subadmin.SelectedValue.ToString() && x.CustomerId == ID).Select(x => new
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

        private void btn_ChargeCommission_Click(object sender, EventArgs e)
        {

        }

        private void btn_MonthlyView_Click(object sender, EventArgs e)
        {
            SuperAdminMonthlyView superAdminMonthlyView_Form = new SuperAdminMonthlyView();
            superAdminMonthlyView_Form.ShowDialog();
        }
    }
}
