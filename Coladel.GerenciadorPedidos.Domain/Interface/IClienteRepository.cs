using Coladel.Core;
using Coladel.Domain.Body;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using System.Linq;

namespace Coladel.Domain.Interface
{
    public interface IClienteRepository : IRepository<Aluno>
    {
        IQueryable<Aluno> BuscarClientesPorFiltro(BuscarClientesFiltroFilter filter);
    }
}
