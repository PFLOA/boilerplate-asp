using Coladel.Domain.Entidades;
using System.Linq;

namespace Coladel.Infra.Repository.QueryExtensions
{
    public static class PagamentoQueryExtension
    {
        public static IQueryable<Pagamento> FiltrarPorMes(this IQueryable<Pagamento> query, short mes)
        {
            if (mes != 0) return query.Where(p => p.DataCadastro.Month == mes);
            return query;
        }

        public static IQueryable<Pagamento> FiltrarPorAno(this IQueryable<Pagamento> query, short ano)
        {
            if (ano != 0) return query.Where(p => p.DataCadastro.Year == ano);
            return query;
        }
    }
}
