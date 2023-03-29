using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entidades;

namespace Application.DTO.Mappeamento
{
    public class MapeamentoGeral : Profile
    {
        public MapeamentoGeral()
        {
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Endereco, EnderecoDTO>();
            CreateMap<ItemPedido, ItemPedidoDTO>();
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
