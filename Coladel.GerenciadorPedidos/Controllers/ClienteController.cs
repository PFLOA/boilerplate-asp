using Coladel.Application.Handlers.Clientes.Request;
using Coladel.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coladel.GerenciadorPedidos.Controllers
{
    public class ClienteController : ApiController
    {
        public ClienteController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> BuscarClientesPorFiltro([FromQuery] BuscarClientesFiltroRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("Guid/{Guid}")]
        [AllowAnonymous]
        public Task<IActionResult> BuscarClientesPorGuid([FromRoute] BuscarClientePorGuidRequest request)
        {
            return _mediator.Send(request);
        }

        [HttpPut]
        [AllowAnonymous]
        public Task<IActionResult> AlterarCliente([FromBody] AlterarClienteRequest request)
        {
            return _mediator.Send(request);
        }
        [HttpPost]
        [AllowAnonymous]
        public Task<IActionResult> CriarCliente([FromBody] CriarClienteRequest request)
        {
            return _mediator.Send(request);
        }

        [HttpPost("ExecutarBackup")]
        [AllowAnonymous]
        public Task<IActionResult> CriarBackupProduto(ExecutarBackupClienteRequest request)
        {
            return _mediator.Send(request);
        }
    }
}
