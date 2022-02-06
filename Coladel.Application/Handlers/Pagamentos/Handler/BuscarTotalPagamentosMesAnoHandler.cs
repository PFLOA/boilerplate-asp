using Coladel.Application.Handlers.Pagamentos.Request;
using Coladel.Application.Handlers.Pagamentos.Response;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Pagamentos.Handler
{
    public class BuscarTotalPagamentosMesAnoHandler : IRequestHandler<BuscarTotalPagamentosMesAnoRequest, IActionResult>
    {
        public readonly IPagamentoRepository _pagamentoRepository;

        public BuscarTotalPagamentosMesAnoHandler(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<IActionResult> Handle(BuscarTotalPagamentosMesAnoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var total = _pagamentoRepository.BuscarTotalMensal(request.Mes, request.Ano);
                return await Task.FromResult(new OkObjectResult(new BuscarTotalPagamentosMesAnoResponse(total, request.Mes, request.Ano)));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
