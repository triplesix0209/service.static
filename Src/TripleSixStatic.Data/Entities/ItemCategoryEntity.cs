using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleSix.Static.Data.Abstracts;

namespace TripleSix.Static.Data.Database.Entities
{
    [Table("MN_ItemCategory")]
    public class ItemCategoryEntity : DmclEntity<ItemCategoryEntity>
    {
        [Key]
        [Column("CategoryId")]
        public int Code { get; set; }

        [Column("Description")]
        public string Name { get; set; }
    }
}
