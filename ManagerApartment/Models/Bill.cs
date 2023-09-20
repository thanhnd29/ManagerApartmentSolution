using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? RequestId { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? BillStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Request? Request { get; set; }
    }
}
