using Colade.Infra.Data;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using Coladel.Domain.Interface;
using Coladel.Infra.Data;
using Coladel.Infra.Repository.QueryExtensions;
using System.Linq;

namespace Coladel.Infra.Repository
{
    public class ClienteRepository : Repository<Aluno>, IClienteRepository
    {
        public ClienteRepository(UserDbContext dbContext) : base(dbContext) { }

        public IQueryable<Aluno> BuscarClientesPorFiltro(BuscarClientesFiltroFilter filter)
        {
            return Set.FiltrarPorNomeCliente(filter.NomeCliente)
                    .FiltrarPorDataCadastro(filter.DataCadastro);
        }
    }
}
