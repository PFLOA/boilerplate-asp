using Coladel.Application.Handlers.Login.Response;
using Coladel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Application.Handlers.Login.Request
{
    public class RealizarLoginRequest : IRequest<IOperationResult<RealizarLoginResponse>>
    {
        public string UserName { get; set; }
        public string Senha { get; set; }

        public RealizarLoginRequest(string userName, string senha)
        {
            UserName = userName;
            Senha = senha;
        }
    }
}
