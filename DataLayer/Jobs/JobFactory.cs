using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Jobs
{
    public class JobFactory : SimpleJobFactory
    {
        IServiceProvider provider;
        public JobFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob)provider.GetService(bundle.JobDetail.JobType);
            } catch (Exception e)
            {
                throw new SchedulerException(string.Format("Problem while instantiaating job '{0}' from Job Factory"));
            }
        }
    }
}
