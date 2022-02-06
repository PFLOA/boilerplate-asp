using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Pagamentos.Request
{
    public class BuscarPagamentosPendentesRequest : IRequest<IActionResult>
    {
    }
}
