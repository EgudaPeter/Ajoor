using System;
using System.Windows.Forms;
using Ajoor.Core;
using System.Linq;
using Ajoor.BusinessLayer.Repos;

namespace Ajoor
{
    public partial class Login : Form
    {
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SuperAdminRepo.ValidateUserCredentials(txt_Username.Text, txt_Password.Text))
                {
                    Utilities.USERNAME = txt_Username.Text;
                    var superAdmin = _SuperAdminRepo.GetAllRecords().Where(x => x.Username == Utilities.USERNAME).FirstOrDefault();
                    _SuperAdminRepo.LogInUser(superAdmin.AdminId, $"{superAdmin.Firstname} {superAdmin.Lastname}");
                    SuperAdminUI superAdminUI_Form = new SuperAdminUI();
                    Hide();
                    superAdminUI_Form.FormClosed += (s, args) => Close();
                    superAdminUI_Form.ShowDialog();
                }
                else if (_SubAdminRepo.ValidateUserCredentials(txt_Username.Text, txt_Password.Text))
                {
                    Utilities.USERNAME = txt_Username.Text;
                    var subAdmin = _SubAdminRepo.GetAllRecords().Where(x => x.Username == Utilities.USERNAME).FirstOrDefault();
                    _SubAdminRepo.LogInUser(subAdmin.SubId, subAdmin.FullName);
                    SubAdminUI subAdminUI_Form = new SubAdminUI();
                    Hide();
                    subAdminUI_Form.FormClosed += (s, args) => Close();
                    subAdminUI_Form.ShowDialog();
                }
                else
                {
                    string message = "Wrong credentials. Please try again.";
                    MessageBox.Show(message, "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Password.Text = string.Empty; txt_Password.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            string message = "Exit application?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }
    }
}
