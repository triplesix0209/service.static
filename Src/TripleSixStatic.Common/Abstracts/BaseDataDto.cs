using System.ComponentModel;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common.Abstracts
{
    public abstract class BaseDataDto : DataDto
    {
        [DisplayName("mã số")]
        public virtual string Code { get; set; }

        [DisplayName("bị xóa?")]
        public virtual bool IsDeleted { get; set; }
    }
}
