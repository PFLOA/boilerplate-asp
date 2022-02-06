using Coladel.Application.Handlers.Clientes.Request;
using Coladel.Application.Handlers.Clientes.Response;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Clientes.Handler
{
    public class BuscarClientePorGuidHandler : IRequestHandler<BuscarClientePorGuidRequest, IActionResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public BuscarClientePorGuidHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<IActionResult> Handle(BuscarClientePorGuidRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Aluno cliente = _clienteRepository.BuscarPorGuid(request.Guid);

                if(cliente is null) return await Task.FromResult(new NotFoundResult());
                return await Task.FromResult(new OkObjectResult(new { OkResult = new CriarClienteResponse(cliente) }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new BadRequestObjectResult(new { Errors = new[] { $"{ex.Message}" } }));
            }
        }
    }
}
