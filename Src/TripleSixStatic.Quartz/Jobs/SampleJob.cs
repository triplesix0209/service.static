using System.Threading.Tasks;
using TripleSix.Static.Common;
using TripleSix.Static.Quartz.Abstracts;
using Quartz;

namespace TripleSix.Static.Quartz.Jobs
{
    public class SampleJob : BaseJob
    {
        public override TriggerBuilder TriggerBuilder(TriggerBuilder builder)
            => base.TriggerBuilder(builder)
            .WithSimpleSchedule(x => x.RepeatForever().WithIntervalInSeconds(600))
            .StartNow();

        public override Task Execute(IJobExecutionContext context)
        {
            var identity = new Identity();
            return Task.CompletedTask;
        }
    }
}
