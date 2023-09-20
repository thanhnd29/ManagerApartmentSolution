using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceDetails = new HashSet<ServiceDetail>();
        }

        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? ServicePrice { get; set; }
        public string? Unit { get; set; }
        public string? ServiceStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
