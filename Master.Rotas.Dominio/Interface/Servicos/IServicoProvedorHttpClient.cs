using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Rotas.Dominio.Interface.Servicos
{
    public interface IServicoProvedorHttpClient
    {
        Task<object> EnviarApi<T>(string uri, T parametros, string uriApi);
    }
}
