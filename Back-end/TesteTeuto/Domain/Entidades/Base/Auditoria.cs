using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Base
{
    public class Auditoria : EntidadeBase
    {
        public DateTime DataDeCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public string EmailUsuarioCriacao { get; private set; }
        public string EmailUsuarioEdicao { get; private set; }

        public void RegistrarAuditoriaCriacao(string emailCriacao)
        {
            DataDeCriacao = DateTime.Now;
            EmailUsuarioCriacao = emailCriacao;
        }

        public void RegistrarAuditoriaAlteracao(string emailAtualizacao)
        {
            DataAtualizacao = DateTime.Now;
            EmailUsuarioEdicao = emailAtualizacao;
        }
    }
}
