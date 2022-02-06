using Coladel.Core.Utils;
using Coladel.Domain.Body;
using Coladel.Domain.Entidades;
using Coladel.Domain.Interface;
using Coladel.Infra.Data;
using System.Security.Cryptography;

namespace Coladel.Infra.Repository
{
    public class UsuarioRepository : UserRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context) { }
        
        public Usuario CriarUsuario(CriarUsuarioRequestBody usuario)
        {
            Hash hash = new Hash(SHA512.Create());

            Usuario usuarioModel = usuario.ToModel();
            usuarioModel.Senha = hash.CriptografarSenha(usuarioModel.Senha, usuarioModel.Guid.ToInt32());
             
            var retorno = Set.Add(usuarioModel);

            context.SaveChanges();

            return retorno.Entity;
        }

        public string RetornarConnectionString()
        {
            return "server=107.161.183.80;port=3306;userid=colaquen_fernando;password=769619Pp**;database=colaquen_banco_teste;";
        }
    }
}
