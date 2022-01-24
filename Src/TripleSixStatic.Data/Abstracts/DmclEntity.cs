using TripleSix.Core.Entities;

namespace TripleSix.Static.Data.Abstracts
{
    public abstract class DmclEntity<TEntity> : BaseEntity<TEntity>
        where TEntity : class, IEntity, new()
    {
    }
}
