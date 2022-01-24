using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleSix.Static.Data.Abstracts;

namespace TripleSix.Static.Data.Database.Entities
{
    [Table("MN_Ward")]
    public class WardEntity : DmclEntity<WardEntity>
    {
        [Key]
        [Column("WardID")]
        public string Code { get; set; }

        [Column("DistrictId")]
        public string DistrictCode { get; set; }

        [Column("Active")]
        public bool IsActive { get; set; }

        [Column("WardName")]
        public string Name { get; set; }

        [ForeignKey(nameof(DistrictCode))]
        public virtual DistrictEntity District { get; set; }
    }
}
