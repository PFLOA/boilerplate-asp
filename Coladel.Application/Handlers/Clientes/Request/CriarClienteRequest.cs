using Coladel.Domain.Body;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Clientes.Request
{
  public class CriarClienteRequest : CriarClienteRequestBody, IRequest<IActionResult> { }
}
