using System;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entidades
{
    public static class Validator
    {
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidationException(error);
        }

        public static void VerificaStringVazia(string valor, string erro)
        {
            if (string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor))
                throw new DomainValidationException(erro);
        }

        public static void TamanhoMaximo(this string valor, int quantidadeMaxima, string erro)
        {
            if (valor.Length > quantidadeMaxima)
                throw new DomainValidationException(erro);
        }

        public static void ObjetoNaoPodeSerNullo(this object entidade, string erro)
        {
            if (entidade is null)
                throw new DomainValidationException(erro);
        }

        public static bool EstaAtivo(this Status status)
        {
            return status == Status.Ativo;
        }
    }
}
