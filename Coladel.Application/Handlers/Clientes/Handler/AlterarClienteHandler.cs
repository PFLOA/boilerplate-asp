using Coladel.Application.Handlers.Clientes.Request;
using Coladel.Core.Extensions;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Clientes.Handler
{
    public class AlterarClienteHandler : IRequestHandler<AlterarClienteRequest, IActionResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public AlterarClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<IActionResult> Handle(AlterarClienteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Aluno cliente = _clienteRepository.BuscarPorGuid(request.Guid);

                if (cliente is null) return await Task.FromResult(new NotFoundObjectResult(new { Error = "Não encontrado o Cliente com o GUID passado. "}));
                request.MappingDifferenceProperties(cliente);

                _clienteRepository.Alterar(cliente);
                
                return await Task.FromResult(new OkResult());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new BadRequestObjectResult(new { Error = ex.Message }));
                throw;
            }
        }
    }
}
