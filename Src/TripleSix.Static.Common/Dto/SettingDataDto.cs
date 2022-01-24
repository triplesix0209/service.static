using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class SettingDataDto : DataDto
    {
        [DisplayName("base url của link kết quả")]
        public string BaseResultUrl { get; set; }

        [DisplayName("danh sách mine type cho phép")]
        public string[] AllowMineTypes { get; set; }

        [DisplayName("kích thuốc file tối đa cho phép (bytes)")]
        public int? MaxFileSize { get; set; }
    }
}
