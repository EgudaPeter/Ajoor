using Ajoor.BusinessLayer.Core;
using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Ajoor.BusinessLayer.Repos;
using System.Speech.Synthesis;
using BusinessLayer.Repos;

namespace Ajoor
{
    public partial class SuperAdminUI : Form
    {
        SuperAdminRepo _SuperAdminRepo = new SuperAdminRepo();
        SubAdminRepo _SubAdminRepo = new SubAdminRepo();
        CustomerRepo _CustomerRepo = new CustomerRepo();
        TransactionRepo _TransactionRepo = new TransactionRepo();
        SettingsRepo _SettingsRepo = new SettingsRepo();
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
            lb_Copyright.Text = $"Copyright © {DateTime.Now.Year}";
            if (!bgw_PullData.IsBusy)
            {
                bgw_PullData.RunWorkerAsync();
            }

            if (!bgw_EndOfMonthOperations.IsBusy)
            {
                bgw_EndOfMonthOperations.RunWorkerAsync();
            }
        }

        private void btn_ExportRecords_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show($"You are about to perform a back-up operation on your database. Operation might take several minutes. \n\nDo you wish to continue?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.Yes:
                    Cursor.Current = Cursors.WaitCursor;
                    if (!bgwBackup.IsBusy)
                    {
                        bgwBackup.RunWorkerAsync();
                    }
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void ExportRecords()
        {
            var dir = @"C:/Ajoor App Database file";
            Directory.CreateDirectory(dir);
            var fileName = "Ajo";
            var path = $"{dir}/{fileName}.bak";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                fi.Delete();
                using (Stream str = fi.Create()) { }
            }
            else
            {
                using (Stream str = fi.Create()) { }
            }
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
            string destinationPath = Path.Combine(dir, $"{databaseName}.bak");
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
                Cursor.Current = Cursors.Default;
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
            Cursor.Current = Cursors.WaitCursor;
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

            lb_TotalAmountCollected.Invoke(new MethodInvoker(delegate
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
            Cursor.Current = Cursors.Default;
        }

        private void btn_TransferCustomer_Click(object sender, EventArgs e)
        {
            TransferCustomers TransferCustomers_Form = new TransferCustomers();
            TransferCustomers_Form.ShowDialog();
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
        }

        private void bgw_EndOfMonthOperations_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var settings = _SettingsRepo.GetConfig();
            if (settings.AllowReminderForClosingMonth)
            {
                var numberOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                var dayInCurrentMonth = DateTime.Now.Day;
                var numberOfDaysToStartRemindingUser = int.Parse(settings.DaysToRemindForClosingMonth);
                var daysLeftInCurrentMonth = numberOfDaysInCurrentMonth - dayInCurrentMonth;
                if (daysLeftInCurrentMonth <= numberOfDaysToStartRemindingUser)
                {
                    settings.StartedRemindingUserToCloseMonthInNonFlexibleMode = true;
                    settings.DaysLeftToRemindUserToCloseMonthInNonFlexibleMode = (daysLeftInCurrentMonth - 1).ToString();
                    _SettingsRepo.SaveSettings(settings);
                    var monthName = Utilities.getMonthName(DateTime.Now.Month);
                    if (settings.ReminderOptions.Equals(Utilities.REMINDEROPTION_USEVOICE))
                    {
                        Utilities.InitSpeaker();
                        switch (daysLeftInCurrentMonth)
                        {
                            case 0:
                                if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month))
                                {
                                    Utilities.speaker.Speak($"Dear {Utilities.USERNAME}. Today is the last day to close this month of {monthName}. Would you like me to close the month of {monthName}?");
                                    Utilities.InitEngine();
                                }
                                else
                                {
                                    Utilities.DisposeSpeaker(Utilities.speaker);
                                }
                                break;
                            case 1:
                                Utilities.speaker.Speak($"Dear {Utilities.USERNAME}. You have {daysLeftInCurrentMonth} day left to close this month of {monthName}.");
                                Utilities.speaker.Speak($"Good bye.");
                                Utilities.DisposeSpeaker(Utilities.speaker);
                                break;
                            default:
                                Utilities.speaker.Speak($"Dear {Utilities.USERNAME}. Including today, you have {daysLeftInCurrentMonth} days left to close this month of {monthName}.");
                                Utilities.speaker.Speak($"Good bye.");
                                Utilities.DisposeSpeaker(Utilities.speaker);
                                break;

                        }
                    }
                }
            }
        }
    }
}
