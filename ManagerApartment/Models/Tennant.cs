using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Tennant
    {
        public Tennant()
        {
            Contracts = new HashSet<Contract>();
        }

        public int TennantId { get; set; }
        public string? TennantName { get; set; }
        public string? TennantEmail { get; set; }
        public string? TennantPassword { get; set; }
        public string? TennantStatus { get; set; }
        public string? TennantPhone { get; set; }
        public string? TennantAddress { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
