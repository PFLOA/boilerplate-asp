using Coladel.Domain.Body;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Coladel.Application.Handlers.Login.Handler.Usuarios.Request
{
    public class CriarUsuarioRequest : CriarUsuarioRequestBody, IRequest<IActionResult>
    {
    }
}
