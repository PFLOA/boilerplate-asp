using Colade.Infra.Data;
using Coladel.Domain.Entidades;
using Coladel.Domain.Filters;
using Coladel.Domain.Interface;
using Coladel.Domain.Retorno;
using Coladel.Infra.Data;
using Coladel.Infra.Repository.QueryExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Coladel.Infra.Repository
{
    public class AulaRepository : Repository<Aula>, IAulaRepository
    {
        public AulaRepository(UserDbContext dbContext) : base(dbContext) { }

        public IQueryable<Aula> BuscarAulasPorFiltro(BuscarAulasFiltroFilter filter) => Set.Include(p => p.Aluno);
        public IQueryable<Aula> BuscarAulasPagamentoPendente() => Set.FiltrarPorAulasPagamentoPendente();

        public BuscarTotalHorasMensalRetorno BuscarTotalHorasMensal(short mes, short ano)
        {
            var totalHorasPendentes = Set
                .FiltrarPorMes(mes)
                .FiltrarPorAno(ano)
                .FiltrarPorDiaMaiorQue((short)DateTime.Now.Day)
                .FiltrarPorCancelada(false)
                .FiltrarPorRealizada(false)
                .Sum(p => p.TempoAula);

            var totalHorasDadas = Set
                .FiltrarPorMes(mes)
                .FiltrarPorAno(ano)
                .FiltrarPorCancelada(false)
                .FiltrarPorRealizada(true)
                .Sum(p => p.TempoAula);

            return new BuscarTotalHorasMensalRetorno(totalHorasPendentes, totalHorasDadas);
        }
        public decimal BuscarTotalPagamentosPendentes() => Set.FiltrarPorPagamentoPendente();
    }
}
