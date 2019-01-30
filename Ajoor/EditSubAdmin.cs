using Ajoor.BusinessLayer.DTO;
using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class EditSubAdmin : Form
    {
        SubAdminRepo _SubAdminRepo = new SubAdminRepo(); bool usernameVerified = true;
        string currentUsername = string.Empty; string currentPhone = string.Empty;
        string currentEmail = string.Empty; SubAdmin subAdmin;
        bool isEmailExisting = false; bool isPhoneNoExisting = false;
        public EditSubAdmin(SubAdmin model)
        {
            InitializeComponent(); subAdmin = model;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Changes will be discared. Leave form?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Close();
                    break;
                case DialogResult.No:
                    return;
            }
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
            if (txt_Username.Text != currentUsername)
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
            if (txt_Phone.Text != currentPhone)
            {
                if (_SubAdminRepo.DoesNumberExists(txt_Phone.Text))
                {
                    lb_DangerPhone.Show(); toolTip.Show("Phone number already exists", lb_DangerPhone); isPhoneNoExisting = true;
                }
                else
                {
                    toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide(); isPhoneNoExisting = false;
                }
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
            if (txt_Email.Text != currentEmail)
            {
                if (_SubAdminRepo.DoesEmailExists(txt_Email.Text))
                {
                    lb_DangerEmail.Show(); toolTip.Show("Email already exists", lb_DangerEmail); isEmailExisting = true;
                }
                else
                {
                    toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide(); isEmailExisting = false;
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
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
                if (usernameVerified == true && txt_Firstname.Text != string.Empty && txt_Lastname.Text != string.Empty
                    && Utilities.IsValidEmail(txt_Email.Text) && isEmailExisting == false && isPhoneNoExisting == false && Utilities.EnsureNumericOnly(txt_Phone.Text)
                    && txt_Email.Text != string.Empty && txt_Phone.Text != string.Empty)
                {
                    SubAdmin subAdmin = new SubAdmin()
                    {
                        SubId = int.Parse(txt_ID.Text),
                        Firstname = txt_Firstname.Text,
                        Lastname = txt_Lastname.Text,
                        Email = txt_Email.Text,
                        PhoneNo = txt_Phone.Text,
                        Username = txt_Username.Text,
                        UpdatedBy = Utilities.USERNAME,
                        UpdatedDate = DateTime.Now.Date
                    };
                    if (_SubAdminRepo.UpdateSubAdmin(subAdmin))
                    {
                        MessageBox.Show("Sub admin updated successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Firstname.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure filled-in information is correct and complete!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditSubAdmin_Load(object sender, EventArgs e)
        {
            lb_DangerEmail.Hide(); lb_DangerFirstname.Hide();
            lb_DangerLastname.Hide();
            lb_DangerPhone.Hide(); lb_DangerUsername.Hide();

            txt_Firstname.Text = subAdmin.Firstname;
            txt_Lastname.Text = subAdmin.Lastname;
            txt_Email.Text = currentEmail = subAdmin.Email;
            txt_Phone.Text = currentPhone = subAdmin.PhoneNo;
            txt_Username.Text = currentUsername = subAdmin.Username;
            txt_ID.Text = subAdmin.SubId.ToString(); txt_ID.ReadOnly = true;
        }

        private void EditSubAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }

        private void txt_Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }

        private void txt_Lastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }

        private void txt_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }

        private void txt_Phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }
    }
}
