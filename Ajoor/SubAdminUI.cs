using Ajoor.BusinessLayer.Repos;
using Ajoor.BusinessLayer.Core;
using System;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class SubAdminUI : Form
    {
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public SubAdminUI()
        {
            InitializeComponent();
        }

        private void SubAdminUI_Load(object sender, EventArgs e)
        {
            lb_LoggedIn.Text = $"Welcome {Utilities.USERNAME}";
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            string message = "You are about to logout. Continue?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    Login login_Form = new Login();
                    Hide();
                    login_Form.FormClosed += (s, args) => Close();
                    login_Form.ShowDialog();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordSubAdmin changePasswordSubAdmin_Form = new ChangePasswordSubAdmin();
            changePasswordSubAdmin_Form.ShowDialog();
        }

        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            CustomerList customerList_Form = new CustomerList();
            customerList_Form.ShowDialog();
        }

        private void btn_Credit_Click(object sender, EventArgs e)
        {
            CreditCustomer creditCustomer_Form = new CreditCustomer();
            creditCustomer_Form.ShowDialog();
        }

        private void btn_Debit_Click(object sender, EventArgs e)
        {
            DebitCustomer debitCustomer_Form = new DebitCustomer();
            debitCustomer_Form.ShowDialog();
        }

        private void btn_Summary_Click(object sender, EventArgs e)
        {
            SummarySubAdminView summaryMonthlyView_Form = new SummarySubAdminView();
            summaryMonthlyView_Form.ShowDialog();
        }
    }
}
