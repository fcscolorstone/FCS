using Microsoft.AspNetCore.Builder;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;

namespace AoteNiu.Service
{
    public static class QuartzExtensions
    {
        public static void UseQuartz(this IApplicationBuilder app, Action<AoteNiuQuartz> configuration)
        {
            // Job Factory through IOC container
            var jobFactory = (IJobFactory)app.ApplicationServices.GetService(typeof(IJobFactory));
            // Set job factory
            AoteNiuQuartz.Instance.UseJobFactory(jobFactory);

            // Run configuration
            configuration.Invoke(AoteNiuQuartz.Instance);
            // Run Quartz
            AoteNiuQuartz.Start();
        }
    }

    /// <summary>
    /// Konfiguration für den Quartz Scheduler
    /// </summary>
    public class AoteNiuQuartz
    {
        // Der verwendete Scheduler
        private IScheduler _scheduler;

        /// <summary>
        /// Verwendete Scheduler
        /// </summary>
        public static IScheduler Scheduler { get { return Instance._scheduler; } }

        // Singleton
        private static AoteNiuQuartz _instance = null;

        /// <summary>
        /// Singleton
        /// </summary>
        public static AoteNiuQuartz Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AoteNiuQuartz();
                }
                return _instance;
            }
        }

        private AoteNiuQuartz()
        {
            Init();
        }

        private async void Init()
        {
            _scheduler = await new StdSchedulerFactory().GetScheduler();
        }

        public IScheduler UseJobFactory(IJobFactory jobFactory)
        {
            Scheduler.JobFactory = jobFactory;
            return Scheduler;
        }

        public async void AddJob<T>(string name, string group, int interval) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(name, group)
                .Build();

            ITrigger jobTrigger = null;
            if (interval > 0)
            {
                jobTrigger = TriggerBuilder.Create()
                    .WithIdentity(name + "Trigger", group)
                    .StartNow()
                    .WithSimpleSchedule(t => t.WithIntervalInSeconds(interval).RepeatForever())
                    .Build();
            }
            else
            {
                jobTrigger = TriggerBuilder.Create()
                    .WithIdentity(name + "Trigger", group)
                    .StartNow()
                    .Build();
            }
        
            await Scheduler.ScheduleJob(job, jobTrigger);
        }

        public async void AddJob<T>(string name, string group, string cron) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(name, group)
                .Build();

            ITrigger jobTrigger = TriggerBuilder.Create()
                    .WithIdentity(name + "Trigger", group)
                    .WithSchedule(CronScheduleBuilder.CronSchedule(cron))
                    .StartNow()
                    .Build();

            await Scheduler.ScheduleJob(job, jobTrigger);
        }

        /// <summary>
        /// Startet den Scheduler
        /// </summary>
        public static async void Start()
        {
            await Scheduler.Start();
        }
    }
}
