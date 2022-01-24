using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class SettingDataDto : DataDto
    {
        [DisplayName("danh sách file extension cho phép")]
        public string[] AllowFileExtensions { get; set; }
    }
}
