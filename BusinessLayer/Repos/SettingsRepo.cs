using BusinessLayer.DTO;
using DataLayer.Model;
using System.Linq;

namespace BusinessLayer.Repos
{
    public class SettingsRepo
    {
        AjoEntities entities = new AjoEntities();
        public bool SaveSettings(SettingsConfig settingsConfig)
        {
            var settingsRecord = entities.cor_settings_config.FirstOrDefault();
            settingsRecord.AllowReminderForClosingMonth = settingsConfig.AllowReminderForClosingMonth;
            settingsRecord.DaysToRemindForClosingMonth = settingsConfig.DaysToRemindForClosingMonth;
            settingsRecord.AllowFlexibleClosingOfMonth = settingsConfig.AllowFlexibleClosingOfMonth;
            settingsRecord.DaysToAllowForFlexibleClosingOfMonth = settingsConfig.DaysToAllowForFlexibleClosingOfMonth;
            settingsRecord.ReminderOptions = settingsConfig.ReminderOptions == string.Empty ? settingsRecord.ReminderOptions : settingsConfig.ReminderOptions;
            return entities.SaveChanges() > 0;
        }

        public SettingsConfig GetConfig()
        {
            var settingsRecord = entities.cor_settings_config.FirstOrDefault();
            SettingsConfig settingsConfig = new SettingsConfig()
            {
                Id = settingsRecord.Id,
                AllowReminderForClosingMonth = settingsRecord.AllowReminderForClosingMonth,
                DaysToRemindForClosingMonth = settingsRecord.DaysToRemindForClosingMonth,
                AllowFlexibleClosingOfMonth = settingsRecord.AllowFlexibleClosingOfMonth,
                DaysToAllowForFlexibleClosingOfMonth = settingsRecord.DaysToAllowForFlexibleClosingOfMonth,
                ReminderOptions = settingsRecord.ReminderOptions
            };
            return settingsConfig;
        }
    }
}
