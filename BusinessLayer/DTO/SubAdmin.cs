﻿using System;

namespace Ajoor.BusinessLayer.DTO
{
    public class SubAdmin
    {
        public long SubId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
