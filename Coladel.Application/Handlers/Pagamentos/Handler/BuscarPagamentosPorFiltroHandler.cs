using Coladel.Application.Handlers.Pagamentos.Request;
using Coladel.Application.Handlers.Pagamentos.Response;
using Coladel.Core.Results;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Pagamentos.Handler
{
    public class BuscarPagamentosPorFiltroHandler : IRequestHandler<BuscarPagamentosPorFiltroRequest, IActionResult>
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public BuscarPagamentosPorFiltroHandler(IPagamentoRepository pagamentoRepository) => _pagamentoRepository = pagamentoRepository;

        public async Task<IActionResult> Handle(BuscarPagamentosPorFiltroRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Pagamento> aulas = _pagamentoRepository.BuscarPagamentosPorFiltro(request);
                return await Task.FromResult(PaginatedResult<BuscarPagamentosPorFiltroResponse>.CreateSuccess(request, aulas, p => p));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
