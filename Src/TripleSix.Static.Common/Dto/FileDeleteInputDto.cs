using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Dto
{
    public class FileDeleteInputDto : DataDto
    {
        [DisplayName("đường dẫn file cần xóa")]
        public string FilePath { get; set; }

        [DisplayName("api key")]
        public string Key { get; set; }
    }
}
