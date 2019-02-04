using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class WelcomeForm : Form
    {
        static string screenPath = Application.StartupPath + "/Welcome.Screen.config.txt";
        static string connectionPath = $"{Application.StartupPath}/Connection.config.txt";
        static string showDialog = string.Empty;
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (chk_DoNotShowScreenAgain.Checked == true)
                {
                    using (StreamWriter writer = new StreamWriter(screenPath))
                    {
                        writer.WriteLine(Cryptography.Encrypt("True", "SuperiorInvestment#"));
                    }
                }
                UsageLock usageLock = new UsageLock();
                Hide();
                usageLock.FormClosed += (s, args) => Close();
                usageLock.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(screenPath))
                {
                    while (!reader.EndOfStream)
                    {
                        showDialog = Cryptography.Decrypt(reader.ReadLine(), "SuperiorInvestment#");
                    }
                }
                if (showDialog == "True")
                {
                    if (_SuperAdminRepo.GetAllRecords().Count() > 0)
                    {
                        Login login_Form = new Login();
                        Hide();
                        login_Form.FormClosed += (s, args) => Close();
                        login_Form.ShowDialog();
                    }
                    else
                    {
                        RegisterSuperAdmin registerSuperAdmin_Form = new RegisterSuperAdmin();
                        Hide();
                        registerSuperAdmin_Form.FormClosed += (s, args) => Close();
                        registerSuperAdmin_Form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
