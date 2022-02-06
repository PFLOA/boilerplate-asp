using Coladel.Application.Handlers.Login.Handler.Usuarios.Request;
using Coladel.Application.Handlers.Usuarios.Response;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coladel.Application.Handlers.Usuarios.Handler
{
  public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioRequest, IActionResult>
  {
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
      _usuarioRepository = usuarioRepository;
    }
    public async Task<IActionResult> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
    {
      try
      {
        Usuario usuario = _usuarioRepository.CriarUsuario(request);
        return await Task.FromResult(new OkObjectResult(new { Usuario = new CriarUsuarioResponse(usuario) }));
      }
      catch (Exception ex)
      {
        return await Task.FromResult(new BadRequestObjectResult(new { Errors = new[] { $"{ex.Message}" } }));
      }
    }
  }
}
