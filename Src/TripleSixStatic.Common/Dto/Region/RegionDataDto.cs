using System.ComponentModel;
using TripleSix.Static.Common.Abstracts;
using TripleSix.Static.Common.Enums;

namespace TripleSix.Static.Common.Dto
{
    public class RegionDataDto : BaseDataDto
    {
        [DisplayName("tên gọi")]
        public virtual string Name { get; set; }

        [DisplayName("phân loại")]
        public RegionTypes Type { get; set; }

        [DisplayName("danh sách khu phục con")]
        public RegionDataDto[] ListChildRegion { get; set; }
    }
}
