using Microsoft.EntityFrameworkCore;
using Master.Rotas.Infra.Dados;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Rotas.Config
{
    public static class RepositorioBaseConfiguracoes
    {
        public static void AddRepositorioBaseConfig(this IServiceCollection services, IConfiguration configuracao)
        {
            //services.AddRepositoriosBase();

            //Entity FrameWork
            //services.AddDbContext<ContextoEntity>(o => o.UseOracle(configuracao["StringConexao"], c => c.UseOracleSQLCompatibility("11")));
            //services.AddScoped<DbContext, ContextoEntity>();
        }
    }
}
