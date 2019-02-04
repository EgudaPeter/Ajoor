using Ajoor.Core;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Ajoor
{
    public partial class LoginRestoreDialog : Form
    {
        static string screenPath = $"{Application.StartupPath}/Dialog.Screen.config.txt";
        static string connectionPath = $"{Application.StartupPath}/Connection.config.txt";
        static string showDialog = string.Empty;
        public LoginRestoreDialog()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (chk_DoNotShowScreenAgain.Checked == true)
            {
                using (StreamWriter writer = new StreamWriter(screenPath))
                {
                    writer.WriteLine(Cryptography.Encrypt("True", "SuperiorInvestment#"));
                }
            }

            WelcomeForm welcomeForm = new WelcomeForm();
            Hide();
            welcomeForm.FormClosed += (s, args) => Close();
            welcomeForm.ShowDialog();

        }

        private void btn_Restore_Click(object sender, EventArgs e)
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

                switch (MessageBox.Show($"You are about to perform a restore operation on your database. Operation might take several minutes. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        if (!bgwRestore.IsBusy)
                        {
                            bgwRestore.RunWorkerAsync();
                        }
                        break;
                    case DialogResult.No:
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportRecords()
        {
            string conString = string.Empty;
            using (StreamReader reader = new StreamReader(connectionPath))
            {
                while (!reader.EndOfStream)
                {
                    conString = reader.ReadLine();
                }
            }
            SqlConnection con = new SqlConnection(conString);
            string databaseName = "Ajo";
            ServerConnection connection = new ServerConnection(con);
            Server sqlServer = new Server(connection);
            Restore rstDatabase = new Restore();
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Database = databaseName;
            string backupfileName = $"{databaseName}.bak";
            string backedUpFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, backupfileName);
            BackupDeviceItem bkpDevice = new BackupDeviceItem(backedUpFile, DeviceType.File);
            rstDatabase.Devices.Add(bkpDevice);
            rstDatabase.ReplaceDatabase = true;
            rstDatabase.SqlRestore(sqlServer);
        }

        private void LoginRestoreDialog_Load(object sender, EventArgs e)
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
                    WelcomeForm welcomeForm = new WelcomeForm();
                    Hide();
                    welcomeForm.FormClosed += (s, args) => Close();
                    welcomeForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = "Please wait while system backs up  data...";
                }));
                ImportRecords();
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = string.Empty;
                }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Result.ToString().Equals("Done"))
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {e.Result.ToString()}", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Operation completed!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WelcomeForm welcomeForm = new WelcomeForm();
                Hide();
                welcomeForm.FormClosed += (s, args) => Close();
                welcomeForm.ShowDialog();
            }
        }
    }
}
