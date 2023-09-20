using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int? ApartmentId { get; set; }
        public int? TennantId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ContractImage { get; set; }
        public string? ContractStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Apartment? Apartment { get; set; }
        public virtual Tennant? Tennant { get; set; }
    }
}
