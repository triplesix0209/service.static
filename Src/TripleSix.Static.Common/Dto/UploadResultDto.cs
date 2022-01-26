using System;
using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class UploadResultDto : DataDto
    {
        [DisplayName("đường dẫn file")]
        public string FilePath { get; set; }

        [DisplayName("Link")]
        public Uri Url { get; set; }
    }
}
