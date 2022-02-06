using System.Text;

namespace Coladel.GerenciadorPedidos.Authentication
{
    public static class AuthenticationJwt
    {
        public static byte[] InitConfigureJwtAuthetication(string jwtKeyConfiguratio)
        {
            return Encoding.ASCII.GetBytes(jwtKeyConfiguratio);
        }
    }
}
