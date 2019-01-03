using Ajoor.Core;
using Ajoor.DTO;
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
    public partial class EditCustomer : Form
    {
        CustomerRepo _CustomerRepo = new CustomerRepo();
        string currentPhone = string.Empty;
        string currentEmail = string.Empty; Customer customer;
        bool isEmailExisting = false; bool isPhoneNoExisting= false;
        public EditCustomer(Customer model)
        {
            InitializeComponent(); customer = model;
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
                if (_CustomerRepo.DoesNumberExists(txt_Phone.Text))
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
                if (_CustomerRepo.DoesEmailExists(txt_Email.Text))
                {
                    lb_DangerEmail.Show(); toolTip.Show("Email already exists", lb_DangerEmail); isEmailExisting = true;
                }
                else
                {
                    toolTip.Hide(lb_DangerEmail); lb_DangerEmail.Hide(); isEmailExisting = false;
                }
            }
        }

        private void txt_Commission_TextChanged(object sender, EventArgs e)
        {
            var result = Utilities.EnsureNumericOnly(txt_Commission.Text);
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
                if (txt_Commission.Text == string.Empty)
                {
                    MessageBox.Show("Commission is required!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Commission.Focus();
                    return;
                }
                if (txt_Firstname.Text != string.Empty && txt_Lastname.Text != string.Empty
                    && Utilities.IsValidEmail(txt_Email.Text) && isEmailExisting == false && isPhoneNoExisting == false && Utilities.EnsureNumericOnly(txt_Phone.Text)
                    && Utilities.EnsureNumericOnly(txt_Commission.Text) && txt_Email.Text != string.Empty && txt_Phone.Text != string.Empty && txt_Commission.Text != string.Empty)
                {
                    Customer customer = new Customer()
                    {
                        CustomerId = int.Parse(txt_ID.Text),
                        FirstName = txt_Firstname.Text,
                        LastName = txt_Lastname.Text,
                        Email = txt_Email.Text,
                        PhoneNumber = txt_Phone.Text,
                        Product = txt_Product.Text,
                        Commission = decimal.Parse(txt_Commission.Text),
                        UpdatedBy = Utilities.USERNAME,
                        UpdateDate = DateTime.Now.Date
                    };
                    if (_CustomerRepo.UpdateCustomer(customer))
                    {
                        MessageBox.Show("Customer updated successfully!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error detail: {ex.Message}", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }

        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            lb_DangerEmail.Hide(); lb_DangerFirstname.Hide();
            lb_DangerLastname.Hide(); lb_DangerCommission.Hide();
            lb_DangerPhone.Hide();

            txt_Firstname.Text = customer.FirstName;
            txt_Lastname.Text = customer.LastName;
            txt_Email.Text = currentEmail = customer.Email;
            txt_Phone.Text = currentPhone = customer.PhoneNumber;
            txt_Commission.Text = customer.Commission.ToString();
            txt_Product.Text = customer.Product;
            txt_ID.Text = customer.CustomerId.ToString(); txt_ID.ReadOnly = true;
            txt_AccountNumber.Text = customer.AccountNumber.ToString();
            txt_AccountNumber.ReadOnly = true;
        }

        private void EditCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {

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

        private void txt_Commission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }

        private void txt_Product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Update_Click(this, new EventArgs());
            }
        }
    }
}
