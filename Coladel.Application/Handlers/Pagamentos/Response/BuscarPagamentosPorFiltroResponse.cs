using Coladel.Core.Extensions;
using Coladel.Domain.Entidades;
using Coladel.Domain.Enum;

namespace Coladel.Application.Handlers.Pagamentos.Response
{
    public class BuscarPagamentosPorFiltroResponse 
    {
        public int QuantidadeAulas { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorHora { get; set; }
        public Materia Materia { get; set; }
        public Aluno Aluno { get; set; }

        public BuscarPagamentosPorFiltroResponse() { }
        public BuscarPagamentosPorFiltroResponse(object mapping) => mapping.MappingProperties(this);

        public static implicit operator BuscarPagamentosPorFiltroResponse(Pagamento mapping) => new BuscarPagamentosPorFiltroResponse(mapping);
    }
}
