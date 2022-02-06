using System;

namespace Coladel.Core.Interfaces
{
    public interface IUpdater<T>
    {
        Guid Alterar(T entidade);
    }
}
