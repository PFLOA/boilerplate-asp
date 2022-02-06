using Coladel.Core.Enum;
using Coladel.Core.Extensions;
using Coladel.Core.Interfaces.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Coladel.Core.Results
{
    public class PaginatedResult<TResult>
    {
        public List<TResult> Data { get; set; }
        public int? TotalCount { get; set; }
        public int? Pages { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }

        public static IActionResult CreateSuccess<TOrigem, TDestino>(IPagination pagination, IQueryable<TOrigem> query, Func<TOrigem, TDestino> func)
        {
            var result = new PaginatedResult<TDestino>();
            return new OkObjectResult(result.Paginate(pagination, query, func));
        }


        #region Funções Privada
        private PaginatedResult<TResult> Paginate<TSource>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
        {
            source = Order(source, pagination);

            if (pagination.CountTotal)
            {
                TotalCount = source.Count();
                double pages = TotalCount.Value / (double)pagination.ItemsPerPage;
                Pages = (int)(pages % 1 == 0 ? pages : pages + 1);
            }

            var paginatedSource = source.Skip((pagination.Page * pagination.ItemsPerPage) - pagination.ItemsPerPage).Take(pagination.ItemsPerPage);

            Page = pagination.Page;
            Data = paginatedSource.ToListResponse(selectFunction).ToList();
            Count = Data.Count;

            return this;
        }
        private IQueryable<TSource> Order<TSource>(IQueryable<TSource> source, IOrderable ordenator)
        {
            if (ordenator.Ordenations is null || !ordenator.Ordenations.Any())
                return source;

            StringBuilder query = new StringBuilder();

            foreach (var ordenation in ordenator.Ordenations)
            {
                query.Append(ordenation.PropertyName);
                query.Append(ordenation.Direction == EnumOrderDirection.Desc ? " desc" : " asc");
                query.Append(",");
            }
            query = query.Remove(query.Length - 1, 1);
            return source.OrderBy(query.ToString());
        }
        #endregion
    }
}
