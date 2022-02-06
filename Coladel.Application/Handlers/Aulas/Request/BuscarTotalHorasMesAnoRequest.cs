using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Aulas.Request
{
    public class BuscarTotalHorasMesAnoRequest : IRequest<IActionResult>
    {
        public short Mes { get; set; }
        public short Ano { get; set; }
    }
}
