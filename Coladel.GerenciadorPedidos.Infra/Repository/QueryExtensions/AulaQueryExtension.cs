using Coladel.Domain.Entidades;
using System.Linq;

namespace Coladel.Infra.Repository.QueryExtensions
{
    public static class AulaQueryExtension
    {
        public static IQueryable<Aula> FiltrarPorMes(this IQueryable<Aula> query, short mes)
        {
            if (mes != 0) return query.Where(p => p.DataAula.Month == mes);
            return query;
        }

        public static IQueryable<Aula> FiltrarPorAno(this IQueryable<Aula> query, short ano)
        {
            if (ano != 0) return query.Where(p => p.DataAula.Year == ano);
            return query;
        }

        public static IQueryable<Aula> FiltrarPorDiaMaiorQue(this IQueryable<Aula> query, short dia)
        {
            if (dia != 0) return query.Where(p => p.DataAula.Day >= dia);
            return query;
        }

        public static IQueryable<Aula> FiltrarPorDiaMenorQue(this IQueryable<Aula> query, short dia)
        {
            if (dia != 0) return query.Where(p => p.DataAula.Day < dia);
            return query;
        }
        public static IQueryable<Aula> FiltrarPorCancelada(this IQueryable<Aula> query, bool isCancelada)
        {
            return query.Where(p => p.IsCancelada == isCancelada);
        }

        public static IQueryable<Aula> FiltrarPorRealizada(this IQueryable<Aula> query, bool isRealizada)
        {
            return query.Where(p => p.IsRealizada == isRealizada);
        }


        public static IQueryable<Aula> FiltrarPorAulasPagamentoPendente(this IQueryable<Aula> query)
        {
            return query.Where(p => p.IsPaga == false);
        }
        

        public static decimal FiltrarPorPagamentoPendente(this IQueryable<Aula> query)
        { 
            return query.Where(p => p.IsPaga == false).Sum(p => p.ValorHora * p.TempoAula);
        }
    }
}
