using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class ApartmentType
    {
        public ApartmentType()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int ApartmentTypeId { get; set; }
        public string? ApartmentTypeName { get; set; }
        public string? ApartmentTypeDescription { get; set; }
        public string? ApartmentTypeStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
