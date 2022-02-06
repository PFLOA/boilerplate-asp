using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Core.Interfaces
{
    public interface IAdder<T>
    {
        T Criar(T entidade);
    }
}
