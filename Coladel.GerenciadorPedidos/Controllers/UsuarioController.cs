using Coladel.Application.Handlers.Login.Handler.Usuarios.Request;
using Coladel.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coladel.GerenciadorPedidos.Controllers
{

    public class UsuarioController : ApiController
    {
        public UsuarioController(IMediator mediator): base(mediator) { }

        [HttpPost]
        [AllowAnonymous]
        public Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioRequest request)
        {
            return _mediator.Send(request);
        }
    }
}
