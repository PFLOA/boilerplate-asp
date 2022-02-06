using Coladel.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Coladel.Application.Handlers.Pagamentos.Request
{
    public class CriarPagamentoRequest : IRequest<IActionResult>
    {
        public short IdAluno { get; set; }
        public int QuantidadeAulas { get; set; }
        public decimal ValorPago { get; set; }
        public Materia Materia { get; set; }
        public List<short> IdAulas { get; set; }
    }
}
