using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Building
    {
        public Building()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingAddress { get; set; }
        public string? BuildingStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
