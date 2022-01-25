using System.ComponentModel;
using Newtonsoft.Json;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;

namespace TripleSix.Static.Common.Dto
{
    public class SettingDataDto : DataDto
    {
        [JsonIgnore]
        public string UploadSecretKey { get; set; }

        [DisplayName("cho phép upload tự do")]
        public bool AllowAnonymous => UploadSecretKey.IsNullOrWhiteSpace();

        [DisplayName("base url của link kết quả")]
        public string BaseResultUrl { get; set; }

        [DisplayName("danh sách mine type cho phép")]
        public string[] AllowMineTypes { get; set; }

        [DisplayName("kích thuốc file tối đa cho phép (bytes)")]
        public int? MaxFileSize { get; set; }
    }
}
