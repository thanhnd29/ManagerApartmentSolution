using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class RequestLog
    {
        public RequestLog()
        {
            StaffLogs = new HashSet<StaffLog>();
        }

        public int RequestLogId { get; set; }
        public int? RequestId { get; set; }
        public string? MaintainItem { get; set; }
        public string? ReqLogDescription { get; set; }
        public string? RegLogStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Request? Request { get; set; }
        public virtual ICollection<StaffLog> StaffLogs { get; set; }
    }
}
