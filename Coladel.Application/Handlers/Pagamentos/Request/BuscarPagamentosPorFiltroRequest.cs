using Coladel.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Pagamentos.Request
{
    public class BuscarPagamentosPorFiltroRequest : BuscarPagamentosFiltroFilter, IRequest<IActionResult>
    {
    }
}
