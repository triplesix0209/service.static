using System;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.Quartz;
using TripleSix.Static.Quartz.Abstracts;
using Quartz;

namespace TripleSix.Static.Quartz.Bootstrap
{
    public class JobScheduler
    {
        private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
        private readonly IScheduler _scheduler;

        public JobScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Start()
        {
            var jobTypes = _assembly.GetTypes()
                .Where(t => t.IsPublic)
                .Where(t => !t.IsAbstract)
                .Where(t => typeof(BaseJob).IsAssignableFrom(t));

            foreach (var jobType in jobTypes)
            {
                var instance = (BaseJob)Activator.CreateInstance(jobType);
                var job = instance.JobBuilder(JobBuilder.Create(jobType)).Build();
                var trigger = instance.TriggerBuilder(TriggerBuilder.Create()).Build();
                _scheduler.ScheduleJob(job, trigger);
            }

            _scheduler.Start();
        }

        internal static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<JobScheduler>()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
               .AsSelf();

            builder.Register(_ => new ScopedDependency("global"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = _ => new NameValueCollection
                {
                    { "quartz.threadPool.threadCount", "3" },
                    { "quartz.scheduler.threadName", "Scheduler" },
                },
                JobScopeConfigurator = (builder, tag) =>
                {
                    builder.Register(_ => new ScopedDependency("job-" + DateTime.UtcNow.ToLongTimeString()))
                        .AsImplementedInterfaces()
                        .InstancePerMatchingLifetimeScope(tag);
                },
            });

            var jobTypes = _assembly.GetTypes()
                .Where(t => t.IsPublic)
                .Where(t => !t.IsAbstract)
                .Where(t => typeof(BaseJob).IsAssignableFrom(t));
            foreach (var jobType in jobTypes)
                builder.RegisterModule(new QuartzAutofacJobsModule(jobType.Assembly) { AutoWireProperties = true });
        }
    }
}
