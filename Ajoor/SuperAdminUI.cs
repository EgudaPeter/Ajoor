using Ajoor.Core;
using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Ajoor.BusinessLayer.Repos;

namespace Ajoor
{
    public partial class SuperAdminUI : Form
    {
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        static string connectionPath = $"{Application.StartupPath}/Connection.config.txt";
        public SuperAdminUI()
        {
            InitializeComponent();
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
            ChangePasswordSuperAdmin changePasswordSuperAdmin_Form = new ChangePasswordSuperAdmin();
            changePasswordSuperAdmin_Form.ShowDialog();
        }

        private void btn_CreateSubAdmin_Click(object sender, EventArgs e)
        {
            SubAdminList subAdminList_Form = new SubAdminList();
            subAdminList_Form.ShowDialog();
        }

        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            SuperAdminCustomerList superAdminCustomerList_Form = new SuperAdminCustomerList();
            superAdminCustomerList_Form.ShowDialog();
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
            Summary summary_Form = new Summary();
            summary_Form.ShowDialog();
        }

        private void SuperAdminUI_Load(object sender, EventArgs e)
        {
            lb_LoggedIn.Text = $"Welcome {Utilities.USERNAME}";
            if (!bgw_PullData.IsBusy)
            {
                bgw_PullData.RunWorkerAsync();
            }
        }

        private void btn_ExportRecords_Click(object sender, EventArgs e)
        {
            try
            {
                //Backup sqlBackup = new Backup(); 
                //sqlBackup.Action = BackupActionType.Database;
                //sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString();
                //sqlBackup.BackupSetName = "FullBackUp";
                //sqlBackup.Database = databaseName;
                //string backupfileName = $"{databaseName}.bak";
                //string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, backupfileName);
                //BackupDeviceItem deviceItem = new BackupDeviceItem($@"{destinationPath}", DeviceType.File);              
                //ServerConnection connection = new ServerConnection(con);                  
                //Server sqlServer = new Server(connection);
                //sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
                //Database db = sqlServer.Databases[databaseName];
                //sqlBackup.Initialize = true;
                //sqlBackup.Checksum = true;
                //sqlBackup.ContinueAfterError = true;   
                //sqlBackup.Devices.Add(deviceItem); 
                //sqlBackup.Incremental = false;
                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);                
                //sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                //sqlBackup.FormatMedia = false;                  
                //sqlBackup.SqlBackup(sqlServer);  
                //sqlBackup.Devices.Remove(deviceItem);
                //MessageBox.Show($"Back-up successful!", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                switch (MessageBox.Show($"You are about to perform a back-up operation on your database. Operation might take several minutes. Do you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        if (!bgwBackup.IsBusy)
                        {
                            bgwBackup.RunWorkerAsync();
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

        private void ExportRecords()
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
            string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{databaseName}.bak");
            ServerConnection connection = new ServerConnection(con);
            Server sqlServer = new Server(connection);
            Backup bkpDatabase = new Backup();
            bkpDatabase.Action = BackupActionType.Database;
            bkpDatabase.Database = databaseName;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(destinationPath, DeviceType.File);
            bkpDatabase.Devices.Add(bkpDevice);
            bkpDatabase.SqlBackup(sqlServer);
            connection.Disconnect();
        }

        private void btn_BalanceLedger_Click(object sender, EventArgs e)
        {
            SuperAdminBalance superAdminBalance_form = new SuperAdminBalance();
            superAdminBalance_form.ShowDialog();
        }

        private void bgwBackup_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = "Please wait while system backs up data...";
                }));
                ExportRecords();
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = string.Empty;
                }));
                e.Result = "Done";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lb_Progress.Invoke(new MethodInvoker(delegate
                {
                    lb_Progress.Text = string.Empty;
                }));
            }
        }

        private void bgwBackup_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Result.ToString().Equals("Done"))
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {e.Result.ToString()}", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Operation completed!", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bgw_PullData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            lb_TotalSubAdmin.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _SubAdminRepo.GetAllRecords().Count();
                    lb_TotalSubAdmin.Text = Utilities.CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            lb_TotalCustomers.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _CustomerRepo.GetAllRecords().Count();
                    lb_TotalCustomers.Text = Utilities.CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            lb_TotalAmountContributed.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _TransactionRepo.GetCreditTransactions().Sum(x => x.AmountContributed) == null ? 0 : _TransactionRepo.GetCreditTransactions().Sum(x => x.AmountContributed);
                    lb_TotalAmountContributed.Text = Utilities.CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            label11.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _TransactionRepo.GetDebitTransactions().Sum(x => x.AmountCollected) == null ? 0 : _TransactionRepo.GetDebitTransactions().Sum(x => x.AmountCollected);
                    lb_TotalAmountCollected.Text = Utilities.CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void btn_TransferCustomer_Click(object sender, EventArgs e)
        {
            TransferCustomers TransferCustomers_Form = new TransferCustomers();
            TransferCustomers_Form.ShowDialog();
        }
    }
}
