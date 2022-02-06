using Coladel.Core.Extensions;
using Coladel.Domain.Entidades;
using Coladel.Domain.Enum;

namespace Coladel.Application.Handlers.Aulas.Response
{
    public class BuscarAulasPorFiltroResponse
    {
        public decimal TempoAula { get; set; }
        public decimal ValorHora { get; set; }
        public bool IsPaga { get; set; }
        public Materia Materia { get; set; }
        public Aluno Aluno { get; set; }

        public BuscarAulasPorFiltroResponse() { }
        public BuscarAulasPorFiltroResponse(object mapping) => mapping.MappingProperties(this);

        public static implicit operator BuscarAulasPorFiltroResponse(Aula mapping) => new BuscarAulasPorFiltroResponse(mapping);
    }
}
