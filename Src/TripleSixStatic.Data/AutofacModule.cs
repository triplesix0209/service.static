using System.Reflection;
using Autofac;
using TripleSix.Static.Data.Contexts;
using Microsoft.Extensions.Configuration;
using TripleSix.Core.ModuleAutofac;

namespace TripleSix.Static.Data
{
    public class AutofacModule : BaseModule
    {
        private readonly Assembly _assembly = Assembly.GetExecutingAssembly();

        public AutofacModule(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterDbContext(c => new DmclContext(Configuration));
            builder.RegisterAllRepository(_assembly);
        }
    }
}
