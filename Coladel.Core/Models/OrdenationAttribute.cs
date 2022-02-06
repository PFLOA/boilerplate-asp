using Coladel.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Core.Models
{
    public class OrdenationAttribute
    {
        public string PropertyName { get; set; }
        public EnumOrderDirection Direction { get; set; }
    }
}
