using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class CustomerList : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        public CustomerList()
        {
            InitializeComponent();
        }


        private void bgwGetRecords_DoWork(object sender, DoWorkEventArgs e)
        {
            dgv_CustomerList.Invoke(new MethodInvoker(delegate { dgv_CustomerList.DataSource = _CustomerRepo.GetAllRecords().Where(x => x.CreatedBy == Utilities.USERNAME).ToList(); }));
            lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_CustomerList.RowCount.ToString(); }));
            e.Result = "Done";
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            if (!bgwGetRecords.IsBusy)
            {
                bgwGetRecords.RunWorkerAsync();
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
