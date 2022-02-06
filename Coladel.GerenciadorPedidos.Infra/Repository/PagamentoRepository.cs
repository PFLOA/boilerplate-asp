using Colade.Infra.Data;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using Coladel.Domain.Interface;
using Coladel.Infra.Data;
using Coladel.Infra.Repository.QueryExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Coladel.Infra.Repository
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(UserDbContext dbContext) : base(dbContext) { }

        public IQueryable<Pagamento> BuscarPagamentosPorFiltro(BuscarPagamentosFiltroFilter filter) => Set.Include(p => p.Aluno).Include(p => p.Aula);

        public decimal BuscarTotalMensal(short mes, short ano) => Set.FiltrarPorMes(mes).FiltrarPorAno(ano).Sum(p => p.ValorPago);
    }
}
