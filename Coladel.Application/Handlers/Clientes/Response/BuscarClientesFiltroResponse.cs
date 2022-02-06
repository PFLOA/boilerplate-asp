using Coladel.Core.Extensions;
using Coladel.Domain.Entidades;
using System;

namespace Coladel.Application.Handlers.Clientes.Response
{
    public class BuscarClientesFiltroResponse
    {
        public short Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeCliente { get; set; }
        public Guid Guid { get; set; }

        public BuscarClientesFiltroResponse(Aluno cliente) => cliente.MappingProperties(this);
    }
}
