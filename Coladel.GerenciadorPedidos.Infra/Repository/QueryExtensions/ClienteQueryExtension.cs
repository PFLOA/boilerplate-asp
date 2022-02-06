using Coladel.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coladel.Infra.Repository.QueryExtensions
{
    public static class ClienteQueryExtension
    {

        public static IQueryable<Aluno> FiltrarPorNomeCliente(this IQueryable<Aluno> query, string nome)
        {
            if (!string.IsNullOrEmpty(nome)) return query.Where(p => p.NomeCliente.ToLower().Contains(nome.ToLower()));
            return query;
        }
        public static IQueryable<Aluno> FiltrarPorDataCadastro(this IQueryable<Aluno> query, DateTime dataCadastro)
        {
            if (dataCadastro != DateTime.MinValue) return query.Where(p => p.DataCadastro.Date == dataCadastro.Date);
            return query;
        }
    }
}
