using Coladel.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Coladel.Application.Handlers.Aulas.Request
{
    public class CriarAulaRequest : IRequest<IActionResult>
    {
        public short IdAluno { get; set; }
        public decimal TempoAula { get; set; }
        public decimal ValorHora { get; set; }
        public bool IsPaga { get; set; }
        public DateTime DataAula { get; set; }
        public Materia Materia { get; set; }
    }
}
