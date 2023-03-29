using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Domain.Exceptions;

namespace Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }

        public Endereco(string rua,string bairro, string cidade, string estado, string CEP, string complemento)
        {
            Atualizar(rua,bairro, cidade, estado, CEP, complemento);
        }

        public void Atualizar(string rua,string bairro, string cidade, string estado, string CEP, string complemento)
        {
            rua.TamanhoMaximo(50, "Bairro ultrapassou quantidade de caracter Permitidas");
            cidade.TamanhoMaximo(50, "Bairro ultrapassou quantidade de caracter Permitidas");
            complemento.TamanhoMaximo(50, "Bairro ultrapassou quantidade de caracter Permitidas");

            this.Rua = rua;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.CEP = CEP;
            this.Complemento = complemento;
        }
    }
}
