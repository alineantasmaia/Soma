﻿//using Btp.Core.Repositorios;
//using Btp.TabelaPreco.Infraestrutura.Dados.Contextos;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Rotas.Config
{
    public static class BaseConfig
    {
        public static void AddBaseConfig(this IServiceCollection services, IConfiguration configuracao)
        {
            //services.AddDbContext<ContextoEntity>(o => o.UseOracle(configuracao["StringConexao"], c => c.UseOracleSQLCompatibility("11")));
            //services.AddScoped<DbContext, ContextoEntity>();
        }
    }
}
