using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class staff
    {
        public staff()
        {
            StaffLogs = new HashSet<StaffLog>();
        }

        public int StaffId { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? StaffStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<StaffLog> StaffLogs { get; set; }
    }
}
