using Coladel.Domain.Interface;
using Coladel.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Coladel.Infra
{
    public static class DependencyInjector
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        }
    }
}
