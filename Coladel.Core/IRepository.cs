using Coladel.Core.Interfaces;

namespace Coladel.Core
{
    public interface IRepository<TEntidade> : IAdder<TEntidade>, IBuscar<TEntidade>, IUpdater<TEntidade>, IRemover<TEntidade>
    {

    }
}
