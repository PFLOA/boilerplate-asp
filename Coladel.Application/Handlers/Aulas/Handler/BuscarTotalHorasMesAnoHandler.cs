using Coladel.Application.Handlers.Aulas.Request;
using Coladel.Application.Handlers.Aulas.Response;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Aulas.Handler
{
    public class BuscarTotalHorasMesAnoHandler : IRequestHandler<BuscarTotalHorasMesAnoRequest, IActionResult>
    {
        private readonly IAulaRepository _aulaRepository;

        public BuscarTotalHorasMesAnoHandler(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task<IActionResult> Handle(BuscarTotalHorasMesAnoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var total = _aulaRepository.BuscarTotalHorasMensal(request.Mes, request.Ano);
                return await Task.FromResult(new OkObjectResult(new BuscarTotalHorasMesAnoResponse(total.TotalHorasDadas, total.TotalHorasPendentes, request.Mes, request.Ano)));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
