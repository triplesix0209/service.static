using System.ComponentModel;
using TripleSix.Static.Common.Abstracts;
using TripleSix.Static.Common.Enums;
using TripleSix.Core.Attributes;

namespace TripleSix.Static.Common.Dto
{
    public class RegionFilterDto : BaseFilterDto
    {
        [DisplayName("lọc theo phân loại")]
        [EnumValidate]
        [DefaultValue(RegionTypes.City)]
        public RegionTypes? Type { get; set; } = RegionTypes.City;

        [DisplayName("lọc theo tên gọi")]
        public string Name { get; set; }

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
