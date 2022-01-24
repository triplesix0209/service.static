﻿using System.Threading.Tasks;
using Quartz;

namespace TripleSix.Static.Quartz.Abstracts
{
    public abstract class BaseJob : IJob
    {
        private string JobName
        {
            get
            {
                var name = GetType().Name;
                if (name.EndsWith("Job") && name.Length > "Job".Length)
                    name = name.Substring(0, name.Length - "Job".Length);

                return name;
            }
        }

        public virtual JobBuilder JobBuilder(JobBuilder builder)
        {
            return builder.WithIdentity(JobName + "Job");
        }

        public virtual TriggerBuilder TriggerBuilder(TriggerBuilder builder)
        {
            return builder.WithIdentity(JobName + "Tigger");
        }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
