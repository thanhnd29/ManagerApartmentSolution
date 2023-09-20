using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class StaffLog
    {
        public int StaffLogId { get; set; }
        public int? StaffId { get; set; }
        public int? RequestLogId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual RequestLog? RequestLog { get; set; }
        public virtual staff? Staff { get; set; }
    }
}
