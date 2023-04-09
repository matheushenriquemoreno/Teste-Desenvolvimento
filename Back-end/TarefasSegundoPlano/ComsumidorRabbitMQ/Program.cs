using ComsumidorRabbitMQ;
using ComsumidorRabbitMQ.Config;
using ComsumidorRabbitMQ.Tarefas;
using Infra.IOC;
using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructure();
        services.AddDependencias();

        services.AddQuartz(Quartz =>
        {
            Quartz.UseMicrosoftDependencyInjectionScopedJobFactory();

            /*Registrando Tarefas */
            Quartz.AdicionandoTarefasAgendadas();

        });

        services.AddQuartzHostedService(
                   q => q.WaitForJobsToComplete = true);

    })
    .Build();

await host.RunAsync();
