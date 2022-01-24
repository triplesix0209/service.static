using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleSix.Static.Data.Abstracts;

namespace TripleSix.Static.Data.Database.Entities
{
    [Table("MN_District")]
    public class DistrictEntity : DmclEntity<DistrictEntity>
    {
        [Key]
        [Column("DistrictId")]
        public string Code { get; set; }

        [Column("CityId")]
        public string CityCode { get; set; }

        [Column("Active")]
        public bool IsActive { get; set; }

        [Column("DistrictName")]
        public string Name { get; set; }

        [ForeignKey(nameof(CityCode))]
        public virtual CityEntity City { get; set; }

        public virtual IList<WardEntity> Wards { get; set; }
    }
}
