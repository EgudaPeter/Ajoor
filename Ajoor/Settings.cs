using Ajoor.BusinessLayer.Core;
using BusinessLayer.DTO;
using BusinessLayer.Repos;
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
    public partial class Settings : Form
    {
        SettingsRepo _SettingsRepo = new SettingsRepo();
        public Settings()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string daysToRemind; string daysToWaitForFlexibleClosing; string reminderOption = string.Empty;
                if (chk_AllowReminder.Checked || chk_AllowFlexibleClosing.Checked)
                {
                    if (!rbtn_UseVoice.Checked && !rbtn_UseDialog.Checked)
                    {
                        MessageBox.Show("Please select a reminder option", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                daysToRemind = daysToWaitForFlexibleClosing = "0";
                if (chk_AllowReminder.Checked)
                {
                    if (cmb_AllowReminderOptions.SelectedItem != null)
                    {
                        daysToRemind = cmb_AllowReminderOptions.SelectedItem.ToString().Split(new char[] { ' ' })[0];
                    }
                    else
                    {
                        MessageBox.Show("Please select an allow reminder for closing month option", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (chk_AllowFlexibleClosing.Checked)
                {
                    if (cmb_FlexibleClosingOfMonthOptions.SelectedItem != null)
                    {
                        daysToWaitForFlexibleClosing = cmb_FlexibleClosingOfMonthOptions.SelectedItem.ToString().Split(new char[] { ' ' })[0];
                    }
                    else
                    {
                        MessageBox.Show("Please select an allow flexible closing of month option", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (rbtn_UseVoice.Checked)
                    reminderOption = Utilities.REMINDEROPTION_USEVOICE;
                if (rbtn_UseDialog.Checked)
                    reminderOption = Utilities.REMINDEROPTION_USEDIALOG;
                SettingsConfig settingsConfig = new SettingsConfig()
                {
                    AllowReminderForClosingMonth = chk_AllowReminder.Checked ? true : false,
                    DaysToRemindForClosingMonth = daysToRemind,
                    AllowFlexibleClosingOfMonth = chk_AllowFlexibleClosing.Checked ? true : false,
                    DaysToAllowForFlexibleClosingOfMonth = daysToWaitForFlexibleClosing,
                    ReminderOptions = reminderOption
                };
                if (_SettingsRepo.SaveSettings(settingsConfig))
                {
                    MessageBox.Show("Operation successful! \n\nPlease note that changes will take effect once system restarts.", "Superior Investment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            string message = "Leave form?";
            switch (MessageBox.Show(message, "Superior Investment", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Close();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_AllowReminderOptions.Enabled = cmb_FlexibleClosingOfMonthOptions.Enabled = false;
                var settingsRecord = _SettingsRepo.GetConfig();

                chk_AllowReminder.Checked = settingsRecord.AllowReminderForClosingMonth == true ? true : false;
                if (chk_AllowReminder.Checked)
                {
                    cmb_AllowReminderOptions.Enabled = true;
                    switch (settingsRecord.DaysToRemindForClosingMonth)
                    {
                        case "1":
                            cmb_AllowReminderOptions.SelectedItem = "1 day to close of month";
                            break;
                        case "2":
                            cmb_AllowReminderOptions.SelectedItem = "2 days to close of month";
                            break;
                        case "3":
                            cmb_AllowReminderOptions.SelectedItem = "3 days to close of month";
                            break;
                        case "4":
                            cmb_AllowReminderOptions.SelectedItem = "4 days to close of month";
                            break;
                        case "5":
                            cmb_AllowReminderOptions.SelectedItem = "5 days to close of month";
                            break;
                        case "6":
                            cmb_AllowReminderOptions.SelectedItem = "6 days to close of month";
                            break;
                        case "7":
                            cmb_AllowReminderOptions.SelectedItem = "7 days to close of month";
                            break;
                    }
                }

                chk_AllowFlexibleClosing.Checked = settingsRecord.AllowFlexibleClosingOfMonth == true ? true : false;
                if (chk_AllowFlexibleClosing.Checked)
                {
                    cmb_FlexibleClosingOfMonthOptions.Enabled = true;
                    switch (settingsRecord.DaysToAllowForFlexibleClosingOfMonth)
                    {
                        case "1":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "1 day after end of month";
                            break;
                        case "2":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "2 days after end of month";
                            break;
                        case "3":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "3 days after end of month";
                            break;
                        case "4":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "4 days after end of month";
                            break;
                        case "5":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "5 days after end of month";
                            break;
                        case "6":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "6 days after end of month";
                            break;
                        case "7":
                            cmb_FlexibleClosingOfMonthOptions.SelectedItem = "7 days after end of month";
                            break;
                    }
                }

                switch (settingsRecord.ReminderOptions)
                {
                    case "Use Voice":
                        rbtn_UseVoice.Checked = true;
                        break;
                    case "Use Dialog":
                        rbtn_UseDialog.Checked = true;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{Utilities.ERRORMESSAGE} \n Error details: {ex.Message}", "Superior Investment!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_AllowReminder_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AllowReminder.Checked)
                cmb_AllowReminderOptions.Enabled = true;
            else
                cmb_AllowReminderOptions.Enabled = false;
        }

        private void chk_AllowFlexibleClosing_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AllowFlexibleClosing.Checked)
                cmb_FlexibleClosingOfMonthOptions.Enabled = true;
            else
                cmb_FlexibleClosingOfMonthOptions.Enabled = false;
        }
    }
}
