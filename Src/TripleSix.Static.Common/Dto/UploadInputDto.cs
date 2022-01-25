using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class UploadInputDto : DataDto
    {
        [DisplayName("tự động phát sinh tên file thay vì sử dụng tên file từ client")]
        [DefaultValue(true)]
        public bool? GenerateFileName { get; set; } = true;

        [DisplayName("danh sách file")]
        public IFormFile[] Files { get; set; }

        [DisplayName("upload key")]
        public string Key { get; set; }
    }
}
