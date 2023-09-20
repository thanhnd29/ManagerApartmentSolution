using System;
using System.Collections.Generic;

namespace ManagerApartment.Models
{
    public partial class AssetHistory
    {
        public AssetHistory()
        {
            Assets = new HashSet<Asset>();
        }

        public int AssetHistoryId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? AssetHisQuantity { get; set; }
        public string? AssetHisItemImage { get; set; }
        public string? AssetHisStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
