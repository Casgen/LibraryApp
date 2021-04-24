using DataLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;


namespace DataLayer
{
    public static class DataLayerServicesExtensions
    {
        private static IScheduler scheduler;
        public static void AddDataLayerServices(this IServiceCollection services)
        {
            scheduler = ConfigureQuartz();
            services.AddSingleton(provider => scheduler);
            services.AddTransient<DebtUpdateJob>();
            
        }

        public static void UseDataLayerConfig(this IApplicationBuilder app)
        {
            scheduler.JobFactory = new JobFactory(app.ApplicationServices);
        }
        private static IScheduler ConfigureQuartz()
        {
            NameValueCollection props = new NameValueCollection
        {
            {"quartz.serializer.type", "binary" },
        };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();
            return scheduler;
        }
    }
}
