using Coladel.Domain.Entidades;

namespace Coladel.Domain.Interface
{
    public interface ILoginRepository
    {
        Usuario LoginUser(string userName, string senha);
    }
}
