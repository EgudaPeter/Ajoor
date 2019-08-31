using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class SettingsConfig
    {
        public long Id { get; set; }
        public bool AllowReminderForClosingMonth { get; set; }
        public string DaysToRemindForClosingMonth { get; set; }
        public string ReminderOptions { get; set; }
        public bool AllowFlexibleClosingOfMonth { get; set; }
        public string DaysToAllowForFlexibleClosingOfMonth { get; set; }
    }
}
