using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            Assets = new HashSet<Asset>();
            Contracts = new HashSet<Contract>();
            Requests = new HashSet<Request>();
        }

        public int ApartmentId { get; set; }
        public int? ApartmentTypeId { get; set; }
        public int? BuildingId { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Sequence { get; set; }
        public string? ApartmentStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ApartmentType? ApartmentType { get; set; }
        public virtual Building? Building { get; set; }
        public virtual Owner? Owner { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
