using Coladel.Core;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using Coladel.Domain.Retorno;
using System.Linq;

namespace Coladel.Domain.Interface
{
    public interface IAulaRepository : IRepository<Aula>
    {
        IQueryable<Aula> BuscarAulasPorFiltro(BuscarAulasFiltroFilter filter);
        IQueryable<Aula> BuscarAulasPagamentoPendente();
        BuscarTotalHorasMensalRetorno BuscarTotalHorasMensal(short mes, short ano);
        decimal BuscarTotalPagamentosPendentes();
    }
}
