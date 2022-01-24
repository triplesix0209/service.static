using System;
using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class UploadResultDto : DataDto
    {
        [DisplayName("Link")]
        public Uri Url { get; set; }
    }
}
