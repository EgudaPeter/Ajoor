using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class ChangePasswordSubAdmin : Form
    {
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public ChangePasswordSubAdmin()
        {
            InitializeComponent();
        }

        private void txt_OldPassword_TextChanged(object sender, EventArgs e)
        {
            if (txt_OldPassword.Text.Length < 6)
            {
                lb_DangerOldPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerOldPassword);
            }
            else
            {
                lb_DangerOldPassword.Hide(); toolTip.Hide(lb_DangerOldPassword);
            }
        }

        private void txt_NewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txt_NewPassword.Text.Length < 6)
            {
                lb_DangerNewPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerNewPassword);
            }
            else
            {
                lb_DangerNewPassword.Hide(); toolTip.Hide(lb_DangerNewPassword);
            }
        }

        private void txt_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txt_ConfirmPassword.Text.Length < 6)
            {
                lb_DangerConfirmPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerConfirmPassword);
            }
            else if (!txt_ConfirmPassword.Text.Equals(txt_NewPassword.Text))
            {
                lb_DangerConfirmPassword.Show(); toolTip.Show("System detects password mismatch.", lb_DangerConfirmPassword);
            }
            else
            {
                lb_DangerConfirmPassword.Hide(); toolTip.Hide(lb_DangerConfirmPassword);
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_OldPassword.Text.Length >= 6 && txt_NewPassword.Text.Length >= 6 && txt_ConfirmPassword.Text.Length >= 6)
                {
                    if (txt_ConfirmPassword.Text.Equals(txt_NewPassword.Text))
                    {
                        if (_SubAdminRepo.ChangePassword(Utilities.USERNAME, txt_NewPassword.Text))
                        {
                            MessageBox.Show("Password has been changed successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("System detects password mismatch!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ConfirmPassword.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePasswordSubAdmin_Load(object sender, EventArgs e)
        {
            lb_DangerConfirmPassword.Hide(); lb_DangerNewPassword.Hide(); lb_DangerOldPassword.Hide();
        }

        private void txt_OldPassword_Leave(object sender, EventArgs e)
        {
            if (txt_OldPassword.Text.Length < 6)
            {
                lb_DangerOldPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerOldPassword);
            }
            else
            {
                lb_DangerOldPassword.Hide(); toolTip.Hide(lb_DangerOldPassword);
            }
        }

        private void txt_NewPassword_Leave(object sender, EventArgs e)
        {
            if (txt_NewPassword.Text.Length < 6)
            {
                lb_DangerNewPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerNewPassword);
            }
            else
            {
                lb_DangerNewPassword.Hide(); toolTip.Hide(lb_DangerNewPassword);
            }
        }

        private void txt_ConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txt_ConfirmPassword.Text.Length < 6)
            {
                lb_DangerConfirmPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerConfirmPassword);
            }
            else if (!txt_ConfirmPassword.Text.Equals(txt_NewPassword.Text))
            {
                lb_DangerConfirmPassword.Show(); toolTip.Show("System detects password mismatch.", lb_DangerConfirmPassword);
            }
            else
            {
                lb_DangerConfirmPassword.Hide(); toolTip.Hide(lb_DangerConfirmPassword);
            }
        }

        private void ChangePasswordSuperAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
