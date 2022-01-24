using System.Reflection;
using TripleSix.Static.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TripleSix.Core.DataContexts;

namespace TripleSix.Static.Data.Contexts
{
    public partial class DmclContext : BaseDataContext
    {

        public DmclContext(IConfiguration configuration)
            : base(Assembly.GetExecutingAssembly(), configuration)
        {
        }

        public DbSet<CityEntity> City { get; set; }

        public DbSet<DistrictEntity> Distrist { get; set; }

        public DbSet<ItemEntity> SaleItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(Configuration.GetValue<string>("Database:DMCL"));
        }
    }
}
