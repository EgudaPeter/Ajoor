using System.Windows.Forms;
using Ajoor.Core;

namespace Ajoor
{
    public partial class RestorePassword : Form
    {
        int count = 5;
        public RestorePassword()
        {
            InitializeComponent();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (count > 0)
                {
                    if (txt_Password.Text.ToLower() == "Restore_Password".ToLower())
                    {
                        Utilities.RESTOREPASSWORD = true;
                        Close();
                    }
                    else
                    {
                        count--;
                        switch (MessageBox.Show($" Password is incorrect. \n You have {count} more chances to retry.\n\n Would to you like to retry?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                return;
                            case DialogResult.No:
                                Close();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"You have exhausted your chances to retry. ", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }
        }
    }
}
