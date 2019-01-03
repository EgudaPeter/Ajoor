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
    public partial class TransferCustomers : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        static string searchQuery = string.Empty;
        public TransferCustomers()
        {
            InitializeComponent();
        }

        private void bgw_PullCustomers_DoWork(object sender, DoWorkEventArgs e)
        {
            if (searchQuery != string.Empty)
            {
                if (Utilities.EnsureNumericOnly(searchQuery))
                {
                    int accountNumber = int.Parse(searchQuery);
                    dgv_Customers.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            dgv_Customers.DataSource = _CustomerRepo.GetAllRecords().Where(x => x.AccountNumber == accountNumber)
                        .Select(x => new
                        {
                            x.CustomerId,
                            x.AccountNumber,
                            x.FirstName,
                            x.LastName,
                            x.PhoneNumber,
                            x.Email,
                            CapturedBy = x.CreatedBy
                        }).ToList();
                        }
                        catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }));
                    lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_Customers.RowCount.ToString(); }));
                }
                else
                {
                    dgv_Customers.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            dgv_Customers.DataSource = _CustomerRepo.GetAllRecords().Where(x => x.FirstName == searchQuery || x.LastName == searchQuery || x.FullName.Contains(searchQuery))
                        .Select(x => new
                        {
                            x.CustomerId,
                            x.AccountNumber,
                            x.FirstName,
                            x.LastName,
                            x.PhoneNumber,
                            x.Email,
                            CapturedBy = x.CreatedBy
                        }).ToList();
                        }
                        catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }));
                    lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_Customers.RowCount.ToString(); }));
                }
            }
            else
            {
                dgv_Customers.Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        dgv_Customers.DataSource = _CustomerRepo.GetAllRecords()
                        .Select(x => new
                        {
                            x.CustomerId,
                            x.AccountNumber,
                            x.FirstName,
                            x.LastName,
                            x.PhoneNumber,
                            x.Email,
                            CapturedBy = x.CreatedBy
                        }).ToList();
                    }
                    catch (Exception ex) { MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_Customers.RowCount.ToString(); }));
            }
        }

        private void bgw_PullSubAdmins_DoWork(object sender, DoWorkEventArgs e)
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
        }

        private void TransferCustomers_Load(object sender, EventArgs e)
        {
            if (!bgw_PullCustomers.IsBusy)
            {
                bgw_PullCustomers.RunWorkerAsync();
            }
            if (!bgw_PullSubAdmins.IsBusy)
            {
                bgw_PullSubAdmins.RunWorkerAsync();
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            searchQuery = txt_Search.Text;
            if (!bgw_PullCustomers.IsBusy)
            {
                bgw_PullCustomers.RunWorkerAsync();
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

        private void btn_Go_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Subadmin.SelectedValue != null)
                {
                    if (dgv_Customers.SelectedRows.Count > 0)
                    {
                        switch (MessageBox.Show("You are about to transfer selected customer(s) to the selected sub-admin. Proceed?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            case DialogResult.Yes:
                                if (!bgw_TransferCustomers.IsBusy)
                                {
                                    bgw_TransferCustomers.RunWorkerAsync();
                                }
                                break;
                            case DialogResult.No:
                                return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select atleast one customer to transfer!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a sub-admin to transfer to!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_TransferCustomers_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = "Please wait while system transfers customers to selected sub-admin...";
                }));
                PerformTransferCustomersProcess();
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = string.Empty;
                }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = string.Empty;
                }));
            }
        }

        private void PerformTransferCustomersProcess()
        {
            try
            {
                List<long> IDs = new List<long>();
                for (int i = 0; i < dgv_Customers.SelectedRows.Count; i++)
                {
                    IDs.Add(long.Parse(dgv_Customers.SelectedRows[i].Cells[0].Value.ToString()));
                }
                foreach (var id in IDs)
                {
                    var customer = _CustomerRepo.GetCustomer(id);
                    cmb_Subadmin.Invoke(new MethodInvoker(delegate
                    {
                        customer.CreatedBy = cmb_Subadmin.SelectedValue.ToString();
                        _CustomerRepo.ChangeCustomerCreator(customer);
                    }));

                    cmb_Subadmin.Invoke(new MethodInvoker(delegate
                    {
                        var customerTransactions = _TransactionRepo.GetAllTransactions().Where(x => x.CustomerId == id);
                        foreach (var customerTransaction in customerTransactions.ToList())
                        {
                            customerTransaction.CreatedBy = cmb_Subadmin.SelectedValue.ToString();
                            _TransactionRepo.ChangeTransactionCreator(customerTransaction);
                        }
                    }));
                }
                MessageBox.Show("Operation completed successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!bgw_PullCustomers.IsBusy)
                {
                    bgw_PullCustomers.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
