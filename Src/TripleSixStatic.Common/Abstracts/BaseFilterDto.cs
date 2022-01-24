using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Abstracts
{
    public abstract class BaseFilterDto : FilterDto
    {
        [DisplayName("từ khóa tìm kiếm")]
        public virtual string Search { get; set; }

        [DisplayName("lọc theo mã số")]
        public virtual string Code { get; set; }

        [DisplayName("lọc các mục bị xóa")]
        public virtual bool? IsDeleted { get; set; }
    }
}
