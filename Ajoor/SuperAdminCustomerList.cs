using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class SuperAdminCustomerList : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public SuperAdminCustomerList()
        {
            InitializeComponent();
        }


        private void bwg_Summary_DoWork(object sender, DoWorkEventArgs e)
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

        private void bgwGetRecords_DoWork(object sender, DoWorkEventArgs e)
        {
            dgv_CustomerList.Invoke(new MethodInvoker(delegate { dgv_CustomerList.DataSource = _CustomerRepo.GetAllRecords().ToList(); }));
            lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerList.RowCount.ToString(); }));
            e.Result = "Done";
        }

        private void SuperAdminCustomerList_Load(object sender, EventArgs e)
        {
            if (!bgwGetRecords.IsBusy)
            {
                bgwGetRecords.RunWorkerAsync();
            }

            if (!bwg_Summary.IsBusy)
            {
                bwg_Summary.RunWorkerAsync();
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

        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer_Form = new CreateCustomer();
            if (createCustomer_Form.ShowDialog() != DialogResult.Yes)
            {
                if (!bgwGetRecords.IsBusy)
                {
                    bgwGetRecords.RunWorkerAsync();
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_CustomerList.SelectedRows.Count > 0)
                {
                    switch (MessageBox.Show("Delete selected record(s)?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        case DialogResult.Yes:
                            List<long> IDs = new List<long>();
                            for (int i = 0; i < dgv_CustomerList.SelectedRows.Count; i++)
                            {
                                IDs.Add(long.Parse(dgv_CustomerList.SelectedRows[i].Cells[0].Value.ToString()));
                            }
                            if (_CustomerRepo.DeleteCustomer(IDs))
                            {
                                MessageBox.Show("Customer(s) deleted successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (!bgwGetRecords.IsBusy)
                                {
                                    bgwGetRecords.RunWorkerAsync();
                                }
                            }
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one customer to delete!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_CustomerList.SelectedRows.Count > 0)
            {
                if (dgv_CustomerList.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please edit customers one at a time!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    long ID = long.Parse(dgv_CustomerList.SelectedRows[0].Cells[0].Value.ToString());
                    var record = _CustomerRepo.GetCustomer(ID);
                    if (record != null)
                    {
                        EditCustomer editCustomer_Form = new EditCustomer(record);
                        if (editCustomer_Form.ShowDialog() != DialogResult.Yes)
                        {
                            if (!bgwGetRecords.IsBusy)
                            {
                                bgwGetRecords.RunWorkerAsync();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select atleast one customer to edit!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bgw_PullReport_SubadminOnly_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dgv_CustomerList.Invoke(new MethodInvoker(delegate 
                {
                    try
                    {
                        if(cmb_Subadmin.SelectedValue.ToString() != null)
                        {
                            if(cmb_Subadmin.SelectedValue.ToString() == string.Empty)
                            {
                                dgv_CustomerList.DataSource = _CustomerRepo.GetAllRecords().ToList();
                            }
                            else
                            {
                                dgv_CustomerList.DataSource = _CustomerRepo.GetAllRecords().Where(x => x.CreatedBy == cmb_Subadmin.SelectedValue.ToString()).ToList();
                            }
                        }
                    }
                    catch(Exception ex) { }
                }));
                lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerList.RowCount.ToString(); }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_Subadmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!bgwSubAdmin.IsBusy)
                {
                    bgwSubAdmin.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
