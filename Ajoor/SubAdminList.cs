using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class SubAdminList : Form
    {
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public SubAdminList()
        {
            InitializeComponent();
        }

        private void bgwGetRecords_DoWork(object sender, DoWorkEventArgs e)
        {
            dgv_SubAdminList.Invoke(new MethodInvoker(delegate { dgv_SubAdminList.DataSource = _SubAdminRepo.GetAllRecords().ToList(); }));
            lb_Total.Invoke(new MethodInvoker(delegate { lb_Total.Text = dgv_SubAdminList.RowCount.ToString(); }));
            Cursor.Current = Cursors.Default;
            e.Result = "Done";
        }

        private void SubAdminList_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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

        private void btn_CreateSubAdmin_Click(object sender, EventArgs e)
        {
            CreateSubAdmin createSubAdmin_Form = new CreateSubAdmin();
            if (createSubAdmin_Form.ShowDialog() != DialogResult.Yes)
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
                if (dgv_SubAdminList.SelectedRows.Count > 0)
                {
                    switch (MessageBox.Show("You are about to delete selected sub admin(s). \n\nThis process will also delete the records created by the selected sub admin(s).\n\nWould you like to proceed?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            List<long> IDs = new List<long>();
                            for (int i = 0; i < dgv_SubAdminList.SelectedRows.Count; i++)
                            {
                                IDs.Add(long.Parse(dgv_SubAdminList.SelectedRows[i].Cells[0].Value.ToString()));
                            }
                            if (_SubAdminRepo.DeleteSubAdmin(IDs))
                            {
                                MessageBox.Show("Sub admin(s) deleted successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Please select atleast one sub admin to delete!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_SubAdminList.SelectedRows.Count > 0)
            {
                if (dgv_SubAdminList.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please edit records one at a time!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    long ID = long.Parse(dgv_SubAdminList.SelectedRows[0].Cells[0].Value.ToString());
                    var record = _SubAdminRepo.GetSubAdmin(ID);
                    if (record != null)
                    {
                        EditSubAdmin editSubAdmin = new EditSubAdmin(record);
                        if (editSubAdmin.ShowDialog() != DialogResult.Yes)
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
                MessageBox.Show("Please select atleast one record to edit!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SubAdminList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
