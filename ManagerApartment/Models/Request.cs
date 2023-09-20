using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Request
    {
        public Request()
        {
            Bills = new HashSet<Bill>();
            RequestLogs = new HashSet<RequestLog>();
            ServiceDetails = new HashSet<ServiceDetail>();
        }

        public int RequestId { get; set; }
        public int? ApartmentId { get; set; }
        public string? ReqDescription { get; set; }
        public DateTime? BookDateTime { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsSequence { get; set; }
        public int? Sequence { get; set; }
        public string? ReqStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Apartment? Apartment { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<RequestLog> RequestLogs { get; set; }
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
