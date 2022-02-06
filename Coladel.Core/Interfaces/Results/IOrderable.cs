using Coladel.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Core.Interfaces.Results
{
    public interface IOrderable
    {
        IList<OrdenationAttribute> Ordenations { get; set; }
    }
}
