using System.ComponentModel;
using TripleSix.Static.Common.Enums;
using TripleSix.Core.Attributes;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class ItemCategoryFilterDto : FilterDto
    {
        [DisplayName("từ khóa tìm kiếm")]
        public string Search { get; set; }

        [DisplayName("lọc theo phân loại")]
        [EnumValidate]
        [DefaultValue(RegionTypes.City)]
        public RegionTypes? Type { get; set; } = RegionTypes.City;

        [DisplayName("lọc theo mã số")]
        public string Code { get; set; }

        [DisplayName("lọc theo tên gọi")]
        public string Name { get; set; }

        [DisplayName("lọc các mục bị xóa")]
        public bool? IsDeleted { get; set; }

        [DisplayName("lọc mã khu vực cha")]
        public string ParentCode { get; set; }

        [DisplayName("lấy các quận/huyện")]
        [DefaultValue(true)]
        public bool? ListDistrict { get; set; } = true;

        [DisplayName("lấy các phường/xã")]
        [DefaultValue(false)]
        public bool? ListWard { get; set; } = false;
    }
}
