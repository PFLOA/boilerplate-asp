using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coladel.Core.Interfaces.Results
{
    public interface IPaginatedResult : IOperationResult<IList>
    {
        int? TotalCount { get; set; }
        int? Pages { get; set; }
        int Count { get; set; }
        int Page { get; set; }

        void Paginate<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction);
    }
}
