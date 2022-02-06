using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Pagamentos.Request
{
    public class BuscarTotalPagamentosMesAnoRequest : IRequest<IActionResult>
    {
        public short Mes { get; set; }
        public short Ano { get; set; }
    }
}
