using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class Asset
    {
        public int AssetId { get; set; }
        public int? AssetHistoryId { get; set; }
        public int? ApartmentId { get; set; }
        public string? AssetName { get; set; }
        public int? Quantity { get; set; }
        public string? AssetDescription { get; set; }
        public string? AssetItemImage { get; set; }
        public string? AssetStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual Apartment? Apartment { get; set; }
        public virtual AssetHistory? AssetHistory { get; set; }
    }
}
