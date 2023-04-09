using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsumidorRabbitMQ.Config
{
    public static class ServiceQuartzConfigurationExtensions
    {

        public static void AddJobAndTrigger<T>(this IServiceCollectionQuartzConfigurator quartz,string cronSchedule)
             where T : IJob
        {
            string jobName = typeof(T).Name;

            if (string.IsNullOrEmpty(cronSchedule))
            {
                throw new Exception($"Não existe a configuração de Cron schedule para o Quartz.NET ");
            }

            // register the job as before
            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronSchedule)); 
        }

    }
}


