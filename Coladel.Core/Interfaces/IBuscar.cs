using System;

namespace Coladel.Core.Interfaces
{
    public interface IBuscar<T>
    {
        T BuscarPorGuid(Guid guid);
        T BuscarPorId(long id);
    }
}
