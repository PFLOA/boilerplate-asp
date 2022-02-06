using Coladel.Application.Handlers.Pagamentos.Request;
using Coladel.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coladel.GerenciadorAulas.Controllers
{
    [AllowAnonymous]
    public class PagamentosController : ApiController
    {
        public PagamentosController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> BuscarPagamentosPorFiltro([FromQuery] BuscarPagamentosPorFiltroRequest request) => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPagamentosPorId([FromQuery] BuscarPagamentosPorIdRequest request) => await _mediator.Send(request);

        [HttpGet("TotalGanhoMesAno")]
        public async Task<IActionResult> BuscarTotalPagamentosMesAno([FromQuery] BuscarTotalPagamentosMesAnoRequest request) => await _mediator.Send(request);

        [HttpGet("TotalPagamentosPendentes")]
        public async Task<IActionResult> BuscarTotalPagamentoPendente() => await _mediator.Send(new BuscarPagamentosPendentesRequest());

        [HttpPost]
        public async Task<IActionResult> CriarPagamento([FromBody] CriarPagamentoRequest request) => await _mediator.Send(request);

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarPagamento([FromBody] AlterarPagamentoRequest request) => await _mediator.Send(request);

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPagamento([FromQuery] DeletarPagamentoRequest request) => await _mediator.Send(request);
    }
}
