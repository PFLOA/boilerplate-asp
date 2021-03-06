using Coladel.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Aulas.Request
{
    public class BuscarAulasPorFiltroRequest : BuscarAulasFiltroFilter, IRequest<IActionResult>
    {
    }
}
