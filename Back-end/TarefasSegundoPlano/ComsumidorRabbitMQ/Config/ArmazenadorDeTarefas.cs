using ComsumidorRabbitMQ.Tarefas;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsumidorRabbitMQ.Config
{
     public static class ArmazenadorDeTarefas
    {

        public static void AdicionandoTarefasAgendadas(this IServiceCollectionQuartzConfigurator quartz)
        {
           
            quartz.AddJobAndTrigger<ComsumindoMensagens>("0/5 * * * * ?");

        }

    }
}
