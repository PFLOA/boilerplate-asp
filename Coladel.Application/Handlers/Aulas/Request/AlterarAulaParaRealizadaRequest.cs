using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Aulas.Request
{
    public class AlterarAulaParaRealizadaRequest : IRequest<IActionResult>
    {
        public short IdAula { get; set; }
    }
}
