using Coladel.Application.Handlers.Aulas.Request;
using Coladel.Application.Handlers.Aulas.Response;
using Coladel.Core.Results;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Aulas.Handler
{
    public class BuscarAulasPorFiltroHandler : IRequestHandler<BuscarAulasPorFiltroRequest, IActionResult>
    {
        private readonly IAulaRepository _aulaRepository;

        public BuscarAulasPorFiltroHandler(IAulaRepository aulaRepository) => _aulaRepository = aulaRepository;

        public async Task<IActionResult> Handle(BuscarAulasPorFiltroRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Aula> aulas = _aulaRepository.BuscarAulasPorFiltro(request);
                return await Task.FromResult(PaginatedResult<BuscarAulasPorFiltroResponse>.CreateSuccess(request, aulas, p => p));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
