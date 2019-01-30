using System;

namespace Ajoor.BusinessLayer.DTO
{
    public class SuperAdmin
    {
        public long AdminId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
