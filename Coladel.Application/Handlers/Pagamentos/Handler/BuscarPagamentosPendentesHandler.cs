using Coladel.Application.Handlers.Aulas.Response;
using Coladel.Application.Handlers.Pagamentos.Request;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Pagamentos.Handler
{
    public class BuscarPagamentosPendentesHandler : IRequestHandler<BuscarPagamentosPendentesRequest, IActionResult>
    {
        private readonly IAulaRepository _aulaRepository;

        public BuscarPagamentosPendentesHandler(IAulaRepository aulaRepository) => _aulaRepository = aulaRepository;

        public async Task<IActionResult> Handle(BuscarPagamentosPendentesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var totalPendente = _aulaRepository.BuscarTotalPagamentosPendentes();
                return await Task.FromResult(new OkObjectResult(new BuscarPagamentosPendentesResponse(totalPendente)));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
