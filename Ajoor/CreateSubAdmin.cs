using Ajoor.BusinessLayer.DTO;
using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class CreateSubAdmin : Form
    {
        SubAdminRepo _SubAdminRepo = new SubAdminRepo(); bool usernameVerified = true;
        bool isEmailExisting = false; bool isPhoneNoExisting = false;
        public CreateSubAdmin()
        {
            InitializeComponent();
        }

        private void txt_Firstname_TextChanged(object sender, EventArgs e)
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

        private void txt_Lastname_TextChanged(object sender, EventArgs e)
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
            var result = _SubAdminRepo.DoesUsernameExist(txt_Username.Text);
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
                return;
            }
            else
            {
                lb_DangerPassword.Hide(); toolTip.Hide(lb_DangerPassword);
            }
        }

        private void txt_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!txt_ConfirmPassword.Text.Equals(txt_Password.Text))
            {
                lb_DangerConfirmPassword.Show(); toolTip.Show("Password mismatch", lb_DangerConfirmPassword);
                return;
            }
            else
            {
                lb_DangerConfirmPassword.Hide(); toolTip.Hide(lb_DangerConfirmPassword);
            }
        }

        private void txt_Phone_TextChanged(object sender, EventArgs e)
        {
            var result = Utilities.EnsureNumericOnly(txt_Phone.Text);
            if (!result)
            {
                lb_DangerPhone.Show(); toolTip.Show("Phone number is not in the right format", lb_DangerPhone);
                return;
            }
            else
            {
                toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide();
            }
            if (txt_Phone.Text.Length < 11)
            {
                lb_DangerPhone.Show(); toolTip.Show("Incorrect phone number", lb_DangerPhone);
                return;
            }
            else
            {
                toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide();
            }
            if (_SubAdminRepo.DoesNumberExists(txt_Phone.Text))
            {
                lb_DangerPhone.Show(); toolTip.Show("Phone number already exists", lb_DangerPhone); isPhoneNoExisting = true;
            }
            else
            {
                toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide(); isPhoneNoExisting = false;
            }
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            if (!Utilities.IsValidEmail(txt_Email.Text))
            {
                lb_DangerEmail.Show(); toolTip.Show("Email is not in the right format", lb_DangerEmail);
                return;
            }
            else
            {
                toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide();
            }
            if (_SubAdminRepo.DoesEmailExists(txt_Email.Text))
            {
                lb_DangerEmail.Show(); toolTip.Show("Email already exists", lb_DangerEmail); isEmailExisting = true;
            }
            else
            {
                toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide(); isEmailExisting = false;
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Firstname.Text == string.Empty)
                {
                    MessageBox.Show("Firstname is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Firstname.Focus();
                    return;
                }
                if (txt_Lastname.Text == string.Empty)
                {
                    MessageBox.Show("Lastname is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Lastname.Focus();
                    return;
                }
                if (txt_Email.Text == string.Empty)
                {
                    MessageBox.Show("Email is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Email.Focus();
                    return;
                }
                if (txt_Phone.Text == string.Empty)
                {
                    MessageBox.Show("Phone number is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }
                if (txt_Password.Text == string.Empty)
                {
                    MessageBox.Show("Password is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Password.Focus();
                    return;
                }
                if (txt_Password.Text == string.Empty)
                {
                    MessageBox.Show("Password is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Password.Focus();
                    return;
                }
                if (txt_ConfirmPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please confirm password!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ConfirmPassword.Focus();
                    return;
                }
                if (usernameVerified == true && txt_Password.Text.Length >= 6 && txt_Password.Text.Equals(txt_ConfirmPassword.Text) && txt_Firstname.Text != string.Empty && txt_Lastname.Text != string.Empty
                    && Utilities.IsValidEmail(txt_Email.Text) && isEmailExisting == false && isPhoneNoExisting == false && Utilities.EnsureNumericOnly(txt_Phone.Text)
                    && txt_Email.Text != string.Empty && txt_Phone.Text != string.Empty)
                {
                    SubAdmin subAdmin = new SubAdmin()
                    {
                        Firstname = txt_Firstname.Text,
                        Lastname = txt_Lastname.Text,
                        Email = txt_Email.Text,
                        PhoneNo = txt_Phone.Text,
                        Password = Cryptography.Encrypt(txt_Password.Text, "SuperiorInvestment#"),
                        Username = txt_Username.Text.ToLower(),
                        CreatedBy = Utilities.USERNAME,
                        CreatedDate = DateTime.Now.Date
                    };
                    if (_SubAdminRepo.AddSubAdmin(subAdmin))
                    {
                        MessageBox.Show("Sub admin added successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Firstname.Text = string.Empty; txt_Firstname.Focus(); lb_DangerFirstname.Hide(); toolTip.Hide(lb_DangerFirstname);
                        txt_Lastname.Text = string.Empty; lb_DangerLastname.Hide(); toolTip.Hide(lb_DangerLastname);
                        txt_Email.Text = string.Empty; toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide();
                        txt_Phone.Text = string.Empty; toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide();
                        txt_Username.Text = string.Empty; lb_DangerUsername.Hide(); toolTip.Hide(lb_DangerUsername);
                        txt_Password.Text = string.Empty; lb_DangerPassword.Hide(); toolTip.Hide(lb_DangerPassword);
                        txt_ConfirmPassword.Text = string.Empty; lb_DangerConfirmPassword.Hide(); toolTip.Hide(lb_DangerConfirmPassword);
                        usernameVerified = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure filled-in information is correct and complete!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CreateSubAdmin_Load(object sender, EventArgs e)
        {
            lb_DangerEmail.Hide(); lb_DangerFirstname.Hide();
            lb_DangerLastname.Hide(); lb_DangerPassword.Hide();
            lb_DangerPhone.Hide(); lb_DangerUsername.Hide();
            lb_DangerConfirmPassword.Hide();
        }

        private void CreateSubAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txt_Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Lastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }
    }
}
