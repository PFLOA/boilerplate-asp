using Coladel.Application.Handlers.Aulas.Request;
using Coladel.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coladel.GerenciadorAulas.Controllers
{
    [AllowAnonymous]
    public class AulasController : ApiController
    {
        public AulasController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> BuscarAulasPorFiltro([FromQuery] BuscarAulasPorFiltroRequest request) => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarDetalhesAulaPorId([FromQuery] BuscarDetalhesAulaPorIdRequest request) => await _mediator.Send(request);

        [HttpGet("TotalHorasMesAno")]
        public async Task<IActionResult> BuscarTotalHorasMesAno([FromQuery] BuscarTotalHorasMesAnoRequest request) => await _mediator.Send(request);

        [HttpPost]
        public async Task<IActionResult> CriarAula([FromBody] CriarAulaRequest request) => await _mediator.Send(request);

        [HttpPut]
        public async Task<IActionResult> MudarEstadoDaAulaPago([FromQuery] MudarEstadoDaAulaPagoRequest request) => await _mediator.Send(request);

        [HttpDelete]
        public async Task<IActionResult> DeletarAula([FromQuery] DeletarAulaRequest request) => await _mediator.Send(request);
    }
}
