using Coladel.Application.Handlers.Login.Request;
using Coladel.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coladel.GerenciadorPedidos.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        public LoginController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RealizarLoginRequest login)
        {
            return await Execute(async () => await _mediator.Send(login));
        }
    }
}
