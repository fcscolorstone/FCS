using Quartz;
using Quartz.Spi;
using System;

namespace AoteNiu.Service
{
    public class AoteNiuJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AoteNiuJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJob x = _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            return x;
        }

        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }

}
