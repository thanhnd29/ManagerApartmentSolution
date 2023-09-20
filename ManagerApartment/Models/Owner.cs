using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerEmail { get; set; }
        public string? OwnerPassword { get; set; }
        public string? OwnerPhone { get; set; }
        public string? OwnerAddress { get; set; }
        public string? OwnerStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
