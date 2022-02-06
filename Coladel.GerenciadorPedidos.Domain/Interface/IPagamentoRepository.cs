using Coladel.Core;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using System.Linq;

namespace Coladel.Domain.Interface
{
    public interface IPagamentoRepository: IRepository<Pagamento>
    {
        IQueryable<Pagamento> BuscarPagamentosPorFiltro(BuscarPagamentosFiltroFilter filter);
        decimal BuscarTotalMensal(short mes, short ano);
    }
}
