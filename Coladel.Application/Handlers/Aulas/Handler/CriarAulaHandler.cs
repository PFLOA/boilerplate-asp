using Coladel.Application.Handlers.Aulas.Request;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Aulas.Handler
{
    public class CriarAulaHandler : IRequestHandler<CriarAulaRequest, IActionResult>
    {
        private readonly IAulaRepository _aulaRepository;

        public CriarAulaHandler(IAulaRepository aulaRepository) => _aulaRepository = aulaRepository;

        public async Task<IActionResult> Handle(CriarAulaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var aula = _aulaRepository.Criar(new Aula(request));
                return await Task.FromResult(new OkObjectResult(new { Sucesso = aula }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ObjectResult(new { Message = ex.Message }));
            }
        }
    }
}
