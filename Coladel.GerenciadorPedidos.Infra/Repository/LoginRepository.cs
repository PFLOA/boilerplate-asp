using Coladel.Core.Utils;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using Coladel.Infra.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Cryptography;

namespace Coladel.Infra.Repository
{
    public class LoginRepository : UserRepository<Usuario>, ILoginRepository
    {
        private readonly IConfiguration _configuration;

        public LoginRepository(ApplicationDbContext context, IConfiguration configuration) : base(context) => _configuration = configuration;

        public Usuario LoginUser(string userName, string senha)
        {
            Hash hash = new Hash(SHA512.Create());

            Usuario usuario = Set.FirstOrDefault(p => p.UserName == userName);
            if (usuario is null) return null;

            string retorno = hash.VerificarSenha(senha, usuario.Guid.ToInt32());
            usuario = Set.FirstOrDefault(p => p.UserName == userName && p.Senha == retorno);

            if(usuario is null) return null;

            _configuration["ConnectionStrings:DynamicConnectionString"] = usuario.ConnectionString;

            return usuario;
        }
    }
}
