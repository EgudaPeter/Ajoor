using Ajoor.BusinessLayer.DTO;
using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using System;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class CreateCustomer : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        bool isEmailExisting = false; bool isPhoneNoExisting = false;
        public CreateCustomer()
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
            if (_CustomerRepo.DoesNumberExists(txt_Phone.Text))
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
            if (_CustomerRepo.DoesEmailExists(txt_Email.Text))
            {
                lb_DangerEmail.Show(); toolTip.Show("Email already exists", lb_DangerEmail); isEmailExisting = true;
            }
            else
            {
                toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide(); isEmailExisting = false;
            }
        }

        private void txt_Commission_TextChanged(object sender, EventArgs e)
        {
            var result = Utilities.EnsureCurrencyOnly(txt_Commission.Text);
            if (!result)
            {
                lb_DangerCommission.Show(); toolTip.Show("Commission is not in the right format", lb_DangerCommission);
                return;
            }
            else
            {
                toolTip.Hide(lb_DangerCommission); lb_DangerCommission.Hide();
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
                if (txt_Commission.Text == string.Empty)
                {
                    MessageBox.Show("Commission is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Commission.Focus();
                    return;
                }
                if (txt_Firstname.Text != string.Empty && txt_Lastname.Text != string.Empty
                    && Utilities.IsValidEmail(txt_Email.Text) && isEmailExisting == false && isPhoneNoExisting == false && Utilities.EnsureNumericOnly(txt_Phone.Text)
                    && Utilities.EnsureCurrencyOnly(txt_Commission.Text) && txt_Email.Text != string.Empty && txt_Phone.Text != string.Empty && txt_Commission.Text != string.Empty)
                {
                    Customer customer = new Customer()
                    {
                        FirstName = txt_Firstname.Text,
                        LastName = txt_Lastname.Text,
                        AccountNumber = _CustomerRepo.GetLastAssignedAccountNumber() + 1,
                        Email = txt_Email.Text,
                        PhoneNumber = txt_Phone.Text,
                        Product = txt_Product.Text,
                        Commission = decimal.Parse(Utilities.RemoveCommasAndDots(txt_Commission.Text)),
                        CreatedBy = Utilities.USERNAME,
                        CreatedDate = DateTime.Now.Date
                    };
                    if (_CustomerRepo.AddCustomer(customer))
                    {
                        MessageBox.Show("Customer added successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Firstname.Text = string.Empty; txt_Firstname.Focus(); toolTip.Hide(lb_DangerFirstname); lb_DangerFirstname.Hide();
                        txt_Lastname.Text = string.Empty; toolTip.Hide(lb_DangerLastname); lb_DangerLastname.Hide();
                        txt_Commission.Text = string.Empty; toolTip.Hide(lb_DangerCommission); lb_DangerCommission.Hide();
                        txt_Email.Text = string.Empty; toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide();
                        txt_Phone.Text = string.Empty; toolTip.Hide(lb_DangerPhone); lb_DangerPhone.Hide();
                        txt_Product.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure filled-in information is correct and complete!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CreateCustomer_Load(object sender, EventArgs e)
        {
            lb_DangerEmail.Hide(); lb_DangerFirstname.Hide();
            lb_DangerLastname.Hide(); lb_DangerCommission.Hide();
            lb_DangerPhone.Hide();
        }

        private void CreateCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txt_Commission_Leave(object sender, EventArgs e)
        {
            txt_Commission.Text = Utilities.CurrencyFormat(txt_Commission.Text);
        }

        private void txt_Commission_Enter(object sender, EventArgs e)
        {
            txt_Commission.Text = Utilities.RemoveCommasAndDots(txt_Commission.Text);
        }

        private void txt_Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void txt_Commission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }

        private void txt_Product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(this, new EventArgs());
            }
        }
    }
}
