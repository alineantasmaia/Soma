using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Master.Rotas.Dominio.Entidade;
using Amazon.Runtime.Internal.Settings;

namespace Master.Rotas.Infra.Dados.Repositorios
{
    public class Context : IDisposable
    {
        private IMongoDatabase _database;
        private IMongoClient _client;

        public Context(IOptions<Settings> options) 
        {
            options.Value.ConnectionString = "mongodb://admin:root@localhost";
            _client = new MongoClient(options.Value.ConnectionString);
            if (options.Value != null )
            {
                _database = _client.GetDatabase(options.Value.Database);
            }
        }

        public IMongoCollection<KnightEntidade> knight
        {
            get
            {
                return _database.GetCollection<KnightEntidade>("KNIGHTS");
            }
        }

        public void Dispose()
        {
            _client = null;
            _database = null;
        }
    }

    public class Settings
    {
        public string Database;
        public string ConnectionString;
    }


}
