using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleSix.Static.Data.Abstracts;

namespace TripleSix.Static.Data.Database.Entities
{
    [Table("MN_City")]
    public class CityEntity : DmclEntity<CityEntity>
    {
        [Key]
        [Column("CityId")]
        public string Code { get; set; }

        [Column("Active")]
        public bool IsActive { get; set; }

        [Column("CityName")]
        public string Name { get; set; }

        public virtual IList<DistrictEntity> Distrists { get; set; }
    }
}
