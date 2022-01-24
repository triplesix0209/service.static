using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripleSix.Static.Data.Abstracts;

namespace TripleSix.Static.Data.Database.Entities
{
    [Table("Tbl_ItemList")]
    public class ItemEntity : DmclEntity<ItemEntity>
    {
        [Key]
        [Column("ItemID")]
        public int Code { get; set; }

        [Column("BarCode")]
        public string BarCode { get; set; }

        [Column("CategoryID")]
        public string CategoryCode { get; set; }

        [Column("ItemName")]
        public string Name { get; set; }

        [Column("Note")]
        public string Note { get; set; }
    }
}
