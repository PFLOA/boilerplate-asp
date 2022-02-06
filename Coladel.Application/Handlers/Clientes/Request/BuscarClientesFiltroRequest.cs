using Coladel.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Coladel.Application.Handlers.Clientes.Request
{
    public class BuscarClientesFiltroRequest : BuscarClientesFiltroFilter, IRequest<IActionResult>
    {
        
    }
}
