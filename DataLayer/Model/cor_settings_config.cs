//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class cor_settings_config
    {
        public long Id { get; set; }
        public bool AllowReminderForClosingMonth { get; set; }
        public string DaysToRemindForClosingMonth { get; set; }
        public string ReminderOptions { get; set; }
        public bool AllowFlexibleClosingOfMonth { get; set; }
        public string DaysToAllowForFlexibleClosingOfMonth { get; set; }
    }
}
