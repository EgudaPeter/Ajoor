using System;
using System.Windows.Forms;
using Ajoor.Core;
using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.DTO;

namespace Ajoor
{
    public partial class RegisterSuperAdmin : Form
    {
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        bool usernameVerified = true;
        public RegisterSuperAdmin()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernameVerified == true && txt_Password.Text.Length >= 6 && txt_Firstname.Text != string.Empty && txt_Lastname.Text != string.Empty)
                {
                    SuperAdmin superAdmin = new SuperAdmin()
                    {
                        Firstname = txt_Firstname.Text,
                        Lastname = txt_Lastname.Text,
                        Password = Cryptography.Encrypt(txt_Password.Text, "SuperiorInvestment#"),
                        Username = txt_Username.Text,
                        CreatedDate = DateTime.Now.Date
                    };
                    var result = _SuperAdminRepo.AddSuperAdmin(superAdmin);
                    if (result > 0)
                    {
                        MessageBox.Show("Registration is successful!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login_Form = new Login();
                        Hide();
                        login_Form.FormClosed += (s, args) => this.Close();
                        login_Form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("There are some errors with information given! Please fill up all required fields!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n \n Error details: {ex.Message}", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Exit setup?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void RegisterSuperAdmin_Load(object sender, EventArgs e)
        {
            lb_DangerFirstname.Hide(); lb_DangerLastname.Hide(); lb_DangerPassword.Hide();
            lb_DangerUsername.Hide();
        }

        private void txt_Firstname_Leave(object sender, EventArgs e)
        {
            if (txt_Firstname.Text == string.Empty)
            {
                lb_DangerFirstname.Show(); toolTip.Show("Firstname is required", lb_DangerFirstname);
            }
            else
            {
                lb_DangerFirstname.Hide(); toolTip.Hide(lb_DangerFirstname);
            }
        }

        private void txt_Lastname_Leave(object sender, EventArgs e)
        {
            if (txt_Lastname.Text == string.Empty)
            {
                lb_DangerLastname.Show(); toolTip.Show("Lastname is required", lb_DangerLastname);
            }
            else
            {
                lb_DangerLastname.Hide(); toolTip.Hide(lb_DangerLastname);
            }
        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {
            var result = _SuperAdminRepo.DoesUsernameExist(txt_Username.Text);
            if (result == true)
            {
                usernameVerified = false;
                lb_DangerUsername.Show(); toolTip.Show("Username exists", lb_DangerUsername);
            }
            else
            {
                lb_DangerUsername.Hide(); toolTip.Hide(lb_DangerUsername); usernameVerified = true;
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            if (txt_Password.Text.Length < 6)
            {
                lb_DangerPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerPassword);
            }
            else
            {
                lb_DangerPassword.Hide(); toolTip.Hide(lb_DangerPassword);
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text.Length < 6)
            {
                lb_DangerPassword.Show(); toolTip.Show("Password must have atleast 6 characters", lb_DangerPassword);
            }
            else
            {
                lb_DangerPassword.Hide(); toolTip.Hide(lb_DangerPassword);
            }
        }

        private void RegisterSuperAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txt_Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Register_Click(this, new EventArgs());
            }
        }

        private void txt_Lastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Register_Click(this, new EventArgs());
            }
        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Register_Click(this, new EventArgs());
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Register_Click(this, new EventArgs());
            }
        }
    }
}
