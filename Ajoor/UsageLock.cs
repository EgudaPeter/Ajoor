using Ajoor.Core;
using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Ajoor.BusinessLayer.Repos;

namespace Ajoor
{
    public partial class UsageLock : Form
    {
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        public UsageLock()
        {
            InitializeComponent();
        }

        static string filePath = Application.StartupPath + "/SystemKey.config.txt";

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

        private void btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Key.Text == "Superior_Investment_Installation_Key")
                {
                    string cpuInfo = string.Empty;
                    ManagementClass mc = new ManagementClass("win32_processor");
                    ManagementObjectCollection moc = mc.GetInstances();

                    foreach (ManagementObject mo in moc)
                    {
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(Cryptography.Encrypt(cpuInfo, "SuperiorInvestment#"));
                    }
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
                else
                {
                    string message = "Wrong installation key. Please try again.";
                    MessageBox.Show(message, "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Key.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                //string message = "config file does not exist. Please contact system developer";
                MessageBox.Show(ex.Message, "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void UsageLock_Load(object sender, EventArgs e)
        {
            try
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
                        if(Utilities.KEY == cpuInfo)
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
                    }
                }
            }
            catch(Exception ex) { }
        }

        private void UsageLock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
