using Coladel.Application.Handlers.Clientes.Request;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Clientes.Handler
{
    public class CriarClienteBackupHandler : IRequestHandler<ExecutarBackupClienteRequest, IActionResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public CriarClienteBackupHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<IActionResult> Handle(ExecutarBackupClienteRequest request, CancellationToken cancellationToken)
        {
            try
            {

                return await Task.FromResult(new OkResult());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new BadRequestObjectResult(new { Errors = new[] { $"{ex.Message}" } }));
            }
        }

        public void CriarCliente(Aluno cliente)
        {
            _clienteRepository.Criar(cliente);
        }
    }
}
