using Application.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComsumidorRabbitMQ.Tarefas
{

    /*atributo. Este atributo impede que o Quartz.NET tente executar o mesmo trabalho simultaneamente*/
    [DisallowConcurrentExecution]
    public class ComsumindoMensagens : IJob
    {

        private readonly IServicoProduto servicoProduto;

        public ComsumindoMensagens(IServicoProduto servicoProduto)
        {
            this.servicoProduto = servicoProduto;
        }

         Task IJob.Execute(IJobExecutionContext context)
        {

            var teste =  servicoProduto.ObterProdutosAtivos().Result;

            foreach (var item in teste) {
                Console.WriteLine($"{item.NomeProduto}, {item.Quatidade}");

            }

            Console.WriteLine("Executando Job");

            return Task.CompletedTask;
        }
    }
}
