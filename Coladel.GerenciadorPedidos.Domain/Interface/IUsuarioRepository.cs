using Coladel.Domain.Body;
using Coladel.Domain.Entidades;

namespace Coladel.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Usuario CriarUsuario(CriarUsuarioRequestBody usuario);
        string RetornarConnectionString();
    }
}
