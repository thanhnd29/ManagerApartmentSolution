using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class ServiceDetail
    {
        public int ServiceDetailId { get; set; }
        public int? ServiceId { get; set; }
        public int? RequestId { get; set; }
        public string? SerDeDescription { get; set; }
        public decimal? SerDePrice { get; set; }
        public int? Amount { get; set; }
        public string? ItemBillImage { get; set; }
        public string? SerDeStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Request? Request { get; set; }
        public virtual Service? Service { get; set; }
    }
}
