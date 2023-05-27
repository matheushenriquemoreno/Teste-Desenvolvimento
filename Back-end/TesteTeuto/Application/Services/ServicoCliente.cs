using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Interfaces.Repositorio;

namespace Application.Services
{
    public class ServicoCliente : IServicoCliente
    {
        public readonly IRepositorioCliente repositorioCliente;
        private readonly IUser user;
        private readonly IMapper _mapper;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IMapper mapper, IUser user)
        {
            this.repositorioCliente = repositorioCliente;
            _mapper = mapper;
            this.user = user;
        }

        public async Task<ClienteDTO> Add(ClienteDTO ClienteDTO)
        {
            var endereco = new Endereco(ClienteDTO.Endereco.Rua,ClienteDTO.Endereco.Bairro, ClienteDTO.Endereco.Cidade, ClienteDTO.Endereco.Estado, ClienteDTO.Endereco.CEP, ClienteDTO.Endereco.Complemento);

            var cliente = new Cliente(ClienteDTO.Nome, ClienteDTO.ClienteStatus, endereco);

            cliente.RegistrarAuditoriaCriacao(user.Email);

            await repositorioCliente.Adicionar(cliente);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObterClientes()
        {
            var clientes = await repositorioCliente.ObterTodosAsync();

            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> ObterClientePeloID(int id)
        {
            var cliente = await repositorioCliente.ObterPorIdAsync(id);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task Atualizar(ClienteDTO ClienteDTO, string emailUsuarioLogado)
        {
            var cliente = await repositorioCliente.ObterPorIdAsync(ClienteDTO.Id);

            cliente.ObjetoNaoPodeSerNullo("Não pode atualizar um Cliente Inexistente");

            cliente.Atualizar(ClienteDTO.Nome, ClienteDTO.ClienteStatus);

            cliente.Endereco.Atualizar(ClienteDTO.Endereco.Rua,ClienteDTO.Endereco.Bairro, ClienteDTO.Endereco.Cidade, ClienteDTO.Endereco.Estado, ClienteDTO.Endereco.CEP, ClienteDTO.Endereco.Complemento);

            cliente.RegistrarAuditoriaAlteracao(emailUsuarioLogado);

            await repositorioCliente.Update(cliente);
        }

        public async Task Remove(int id)
        {
            var cliente = await repositorioCliente.ObterPorIdAsync(id);

            if (cliente.PedidosDoCliente.Count() > 0)
                throw new OperacaoInvalidaException("Não pode excluir Cliente que possue pedidos");

            await repositorioCliente.Remover(cliente);
        }
    }
}
