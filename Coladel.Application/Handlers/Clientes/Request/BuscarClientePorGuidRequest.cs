using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Application.Handlers.Clientes.Request
{
    public class BuscarClientePorGuidRequest : IRequest<IActionResult>
    {
        public Guid Guid { get; set; }
    }
}
