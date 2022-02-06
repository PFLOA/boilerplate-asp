using Coladel.Application.Handlers.Pagamentos.Request;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Pagamentos.Handler
{
    public class CriarPagamentoHandler : IRequestHandler<CriarPagamentoRequest, IActionResult>
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public CriarPagamentoHandler(IPagamentoRepository pagamentoRepository) => _pagamentoRepository = pagamentoRepository;

        public async Task<IActionResult> Handle(CriarPagamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.IdAulas.ForEach((idAula) =>
                {
                    var pagamento = _pagamentoRepository.Criar(new Pagamento(request, idAula));
                });

                return await Task.FromResult(new OkResult());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
