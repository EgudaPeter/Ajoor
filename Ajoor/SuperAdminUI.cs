using Ajoor.BusinessLayer.Core;
using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Ajoor.BusinessLayer.Repos;
using BusinessLayer.Repos;
using BusinessLayer.DTO;
using static Ajoor.BusinessLayer.Core.Utilities;

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
            lb_LoggedIn.Text = $"Welcome {USERNAME}";
            lb_Copyright.Text = $"Copyright © {DateTime.Now.Year}";
            if (!bgw_PullData.IsBusy)
            {
                bgw_PullData.RunWorkerAsync();
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
                MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"{ERRORMESSAGE} \n Error details: {e.Result.ToString()}", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    lb_TotalSubAdmin.Text = CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            lb_TotalCustomers.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _CustomerRepo.GetAllRecords().Count();
                    lb_TotalCustomers.Text = CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            lb_TotalAmountContributed.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _TransactionRepo.GetCreditTransactions().Sum(x => x.AmountContributed) == null ? 0 : _TransactionRepo.GetCreditTransactions().Sum(x => x.AmountContributed);
                    lb_TotalAmountContributed.Text = CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));

            lb_TotalAmountCollected.Invoke(new MethodInvoker(delegate
            {
                try
                {
                    var count = _TransactionRepo.GetDebitTransactions().Sum(x => x.AmountCollected) == null ? 0 : _TransactionRepo.GetDebitTransactions().Sum(x => x.AmountCollected);
                    lb_TotalAmountCollected.Text = CurrencyFormat(count.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void bgw_PullData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!bgw_EndOfMonthOperations.IsBusy)
            {
                bgw_EndOfMonthOperations.RunWorkerAsync();
            }
        }

        private void bgw_EndOfMonthOperations_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var settings = _SettingsRepo.GetConfig();
                if (settings.AllowReminderForClosingMonth)
                {
                    AllowNonFlexibleClosingOfMonthOperation(settings);
                }
                if (settings.AllowFlexibleClosingOfMonth)
                {
                    if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
                    {
                        AllowFlexibleClosingOfMonthOperation(settings);
                    }
                }
                else
                { 
                    if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
                    {
                        var previousMonthName = GetMonthName(DateTime.Now.Month - 1);
                        ForcefullyCloseMonth(settings, previousMonthName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllowNonFlexibleClosingOfMonthOperation(SettingsConfig settings)
        {
            var numberOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var dayInCurrentMonth = DateTime.Now.Day;
            var numberOfDaysToStartRemindingUser = int.Parse(settings.DaysToRemindForClosingMonth);
            var daysLeftInCurrentMonth = numberOfDaysInCurrentMonth - dayInCurrentMonth;
            var previousMonthName = GetMonthName(DateTime.Now.Month - 1);
            if (daysLeftInCurrentMonth <= numberOfDaysToStartRemindingUser)
            {
                var monthName = GetMonthName(DateTime.Now.Month);
                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEVOICE))
                {
                    ReminderOptionUseVoiceOperation(daysLeftInCurrentMonth, monthName, string.Empty, Modes.NonFlexible);
                }

                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEDIALOG))
                {
                    ReminderOptionUseDialogOperation(daysLeftInCurrentMonth, monthName, string.Empty, Modes.NonFlexible);
                }
            }
            else
            {
                if (!settings.AllowFlexibleClosingOfMonth)
                {
                    if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
                    {
                        ForcefullyCloseMonth(settings, previousMonthName);
                    }
                }
            }
        }

        private void AllowFlexibleClosingOfMonthOperation(SettingsConfig settings)
        {
            var dayInCurrentMonth = DateTime.Now.Day;
            var numberOfDaysAllowedInFlexibleMode = int.Parse(settings.DaysToAllowForFlexibleClosingOfMonth);
            var daysLeftInFlexibleMode = numberOfDaysAllowedInFlexibleMode - dayInCurrentMonth;
            var monthName = GetMonthName(DateTime.Now.Month);
            var previousMonthName = GetMonthName(DateTime.Now.Month - 1);
            if (dayInCurrentMonth <= numberOfDaysAllowedInFlexibleMode)
            {
                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEVOICE))
                {
                    ReminderOptionUseVoiceOperation(daysLeftInFlexibleMode, monthName, previousMonthName, Modes.Flexible);
                }

                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEDIALOG))
                {
                    ReminderOptionUseDialogOperation(daysLeftInFlexibleMode, monthName, previousMonthName, Modes.Flexible);
                }
            }
            else
            {
                ForcefullyCloseMonth(settings, previousMonthName);
            }
        }

        private void ReminderOptionUseVoiceOperation(int days, string monthName, string previousMonthName, Modes mode)
        {
            if (mode == Modes.NonFlexible)
                OperationForNonFlexibleModeUsingVoice(days, monthName);
            else
                OperationForFlexibleModeUsingVoice(days, monthName, previousMonthName);
        }

        private void ReminderOptionUseDialogOperation(int days, string monthName, string previousMonthName, Modes mode)
        {
            if (mode == Modes.NonFlexible)
                OperationForNonFlexibleModeUsingDialog(days, monthName);
            else
                OperationForFlexibleModeUsingDialog(days, monthName, previousMonthName);
        }

        private void OperationForNonFlexibleModeUsingVoice(int days, string monthName)
        {
            InitSpeaker();
            int daysLeftInCurrentMonth = days;
            switch (daysLeftInCurrentMonth)
            {
                case 0:
                    if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month))
                    {
                        speaker.Speak($"Hello {USERNAME}. Today is the last day to close this month of {monthName}. Would you like me to close the month of {monthName}?");
                        InitEngine();
                    }
                    else
                    {
                        DisposeSpeaker(speaker);
                    }
                    break;
                case 1:
                    speaker.Speak($"Hello {USERNAME}. You have {daysLeftInCurrentMonth} day left to close this month of {monthName}.");
                    speaker.Speak($"Good bye.");
                    DisposeSpeaker(speaker);
                    break;
                default:
                    speaker.Speak($"Hello {USERNAME}. Including today, you have {daysLeftInCurrentMonth} days left to close this month of {monthName}.");
                    speaker.Speak($"Good bye.");
                    DisposeSpeaker(speaker);
                    break;

            }
        }

        private void OperationForNonFlexibleModeUsingDialog(int days, string monthName)
        {
            int daysLeftInCurrentMonth = days;
            switch (daysLeftInCurrentMonth)
            {
                case 0:
                    if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month))
                    {
                        switch (MessageBox.Show($"Hello {USERNAME}. Today is the last day to close this month of {monthName}. \n\nWould you like me to close the month of {monthName} now?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            case DialogResult.Yes:
                                MessageBox.Show($"Alright {USERNAME}. I am about to close the month. This might take some time. \n\nPlease note that once the month has been closed, no postings will be allowed anymore for the day.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                UseWaitCursor = true;
                                if (_TransactionRepo.CloseMonthOperation())
                                {
                                    MessageBox.Show($"Month of {monthName} has been closed. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                UseWaitCursor = false;
                                break;
                            case DialogResult.No:
                                MessageBox.Show($"Alright {USERNAME}. Please endeavour to close the month today. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                    break;
                case 1:
                    MessageBox.Show($"Hello {USERNAME}. You have {daysLeftInCurrentMonth} day left to close this month of {monthName}. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show($"Hello {USERNAME}. Including today, you have {daysLeftInCurrentMonth} days left to close this month of {monthName}. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

            }
        }

        private void OperationForFlexibleModeUsingVoice(int days, string monthName, string previousMonthName)
        {
            InitSpeaker();
            int daysLeftInFlexibleMode = days; string message = string.Empty;
            switch (daysLeftInFlexibleMode)
            {
                case 0:
                    message = $"Today is the last day in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingVoice(monthName, previousMonthName, message);
                    break;
                case 1:
                    message = $"You have {daysLeftInFlexibleMode} day left in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingVoice(monthName, previousMonthName, message);
                    break;
                default:
                    message = $"Including today, you have {daysLeftInFlexibleMode} days left in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingVoice(monthName, previousMonthName, message);
                    break;

            }
        }

        private void OperationForFlexibleModeUsingDialog(int days, string monthName, string previousMonthName)
        {
            int daysLeftInFlexibleMode = days; string message = string.Empty;
            switch (daysLeftInFlexibleMode)
            {
                case 0:
                    message = $"Today is the last day in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingDialog(monthName, previousMonthName, message);
                    break;
                case 1:
                    message = $"You have {daysLeftInFlexibleMode} day left in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingDialog(monthName, previousMonthName, message);
                    break;
                default:
                    message = $"Including today, you have {daysLeftInFlexibleMode} days left in the new month of {monthName} to close the previous month of {previousMonthName}";
                    DoActionForFlexibleModeUsingDialog(monthName, previousMonthName, message);
                    break;

            }
        }

        private void DoActionForFlexibleModeUsingVoice(string monthName, string previousMonthName, string message)
        {
            if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
            {
                speaker.Speak($"Hello {USERNAME}. {message}. Would you like me to close the previous month of {previousMonthName} now?");
                InitEngine();
            }
            else
            {
                DisposeSpeaker(speaker);
            }
        }

        private void DoActionForFlexibleModeUsingDialog(string monthName, string previousMonthName, string message)
        {
            if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
            {
                switch (MessageBox.Show($"Hello {USERNAME}. {message}. \n\nWould you like me to close the previous month of {previousMonthName} now?", "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        MessageBox.Show($"Alright {USERNAME}. I am about to close the previous month of {previousMonthName}. \n\nThis might take some time.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        UseWaitCursor = true;
                        if (_TransactionRepo.ClosePreviousMonthOperation())
                        {
                            MessageBox.Show($"Previous month of {previousMonthName} has been closed. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        UseWaitCursor = false;
                        break;
                    case DialogResult.No:
                        MessageBox.Show($"Alright {USERNAME}. But Please endeavour to close the previous month of {previousMonthName} soon. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void ForcefullyCloseMonth(SettingsConfig settings, string previousMonthName)
        {
            if (!_TransactionRepo.HasMonthBeenClosed(DateTime.Now.Month - 1))
            {
                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEVOICE))
                {
                    InitSpeaker();
                    speaker.Speak($"Hello {USERNAME}. You have surpassed the maximum days available to close the previous month of {previousMonthName}. I am forcefully closing the previous month now.");
                    speaker.Speak($"Closing previous month of {previousMonthName}");
                    UseWaitCursor = true;
                    _TransactionRepo.ClosePreviousMonthOperation();
                    UseWaitCursor = false;
                    speaker.Speak($"Previous month of {previousMonthName} has been closed.");
                    speaker.Speak($"Good bye.");
                    DisposeSpeaker(speaker);
                }
                if (settings.ReminderOptions.Equals(REMINDEROPTION_USEDIALOG))
                {
                    UseWaitCursor = true;
                    _TransactionRepo.ClosePreviousMonthOperation();
                    UseWaitCursor = false;
                    MessageBox.Show($"Month of {previousMonthName} has been forcefully closed. \n\nGood bye.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
