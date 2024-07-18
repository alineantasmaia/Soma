using Master.Rotas.Dominio.Interface.Servicos;
using Master.Rotas.Dominio.Services;
using Master.Rotas.Infra.Dados;
using Microsoft.Extensions.DependencyInjection;
using Master.Rotas.Dominio.Interface.Repositorios;
using Master.Rotas.Infra.Dados.Repositorios;
using Master.Rotas.Infra.Servicos;


namespace Master.Rotas.Config
{
    public static class InjecaoDepedenciaConfiguracoes
    {
        public static void AddInjecaoDependenciaConfig(this IServiceCollection services)
        {
            services.AddScoped<IServicoRotas,ServiceRotas>();
            services.AddScoped<IRepositorioRotas, RepositorioRota>();

            services.AddScoped<IServicoProvedorHttpClient, ServicoProvedorHttpClient>();
        }

    }
}
