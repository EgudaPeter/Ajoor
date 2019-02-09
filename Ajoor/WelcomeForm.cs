using Ajoor.BusinessLayer.Repos;
using Ajoor.Core;
using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class WelcomeForm : Form
    {
        static string screenPath = Application.StartupPath + "/Welcome.Screen.config.txt";
        static string connectionPath = $"{Application.StartupPath}/Connection.config.txt";
        static string filePath = Application.StartupPath + "/SystemKey.config.txt";
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
                    if (File.Exists(filePath))
                    {
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            while (!reader.EndOfStream)
                            {
                                Utilities.KEY = reader.ReadLine();
                            }
                        }
                        if (Utilities.KEY != string.Empty)
                        {
                            Utilities.KEY = Cryptography.Decrypt(Utilities.KEY, "SuperiorInvestment#");
                            string cpuInfo = string.Empty;
                            ManagementClass mc = new ManagementClass("win32_processor");
                            ManagementObjectCollection moc = mc.GetInstances();
                            foreach (ManagementObject mo in moc)
                            {
                                cpuInfo = mo.Properties["processorID"].Value.ToString();
                                break;
                            }
                            if (Utilities.KEY == cpuInfo)
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
                                    registerSuperAdmin_Form.FormClosed += (s, args) => this.Close();
                                    registerSuperAdmin_Form.ShowDialog();
                                }
                            }
                            else
                            {
                                UsageLock usageLock = new UsageLock();
                                Hide();
                                usageLock.FormClosed += (s, args) => Close();
                                usageLock.ShowDialog();
                            }
                        }
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
