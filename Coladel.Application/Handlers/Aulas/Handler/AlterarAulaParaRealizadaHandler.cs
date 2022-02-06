using Coladel.Application.Handlers.Aulas.Request;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Aulas.Handler
{
    public class AlterarAulaParaRealizadaHandler : IRequestHandler<AlterarAulaParaRealizadaRequest, IActionResult>
    {
        private readonly IAulaRepository _aulaRepository;

        public AlterarAulaParaRealizadaHandler(IAulaRepository aulaRepository) => _aulaRepository = aulaRepository;

        public async Task<IActionResult> Handle(AlterarAulaParaRealizadaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var aula = _aulaRepository.BuscarPorId(request.IdAula);
                aula.AlterarParaRealizada();

                var guidAula = _aulaRepository.Alterar(aula);
                return await Task.FromResult(new OkObjectResult(new { Guid = aula }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
