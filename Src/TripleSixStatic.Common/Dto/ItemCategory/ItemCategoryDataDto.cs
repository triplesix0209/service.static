using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class ItemCategoryDataDto : DataDto
    {
        [DisplayName("mã số")]
        public string Code { get; set; }

        [DisplayName("tên gọi")]
        public string Name { get; set; }

        [DisplayName("bị xóa?")]
        public bool IsDeleted { get; set; }
    }
}
