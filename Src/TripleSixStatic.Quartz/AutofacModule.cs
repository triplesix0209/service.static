using System.Reflection;
using Autofac;
using TripleSix.Static.Quartz.Bootstrap;
using Microsoft.Extensions.Configuration;
using TripleSix.Core.ModuleAutofac;

namespace TripleSix.Static.Quartz
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

            JobScheduler.Register(builder);
        }
    }
}
