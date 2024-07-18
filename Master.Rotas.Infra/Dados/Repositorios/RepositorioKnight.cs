using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Entidade;
using Master.Rotas.Dominio.Interface.Repositorios;
using Master.Rotas.Infra.Servicos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Master.Rotas.Infra.Dados.Repositorios
{
    public class RepositorioKnight : IRepositorioKnight
    {
        private readonly Context _context;

        public RepositorioKnight(IOptions<Settings> options)
        {
            _context = new Context(options);
        }

        public async Task<bool> Alterar(KnightEntidade knight)
        {
            try
            {
                IMongoCollection<KnightEntidade> knightCollection = _context.knight;
                Expression<Func<KnightEntidade, bool>> filter = x => x.Id.Equals(knight.Id);

                KnightEntidade entidade = knightCollection.Find(filter).FirstOrDefault();
                if (entidade != null)
                {
                    entidade.Id = knight.Id;
                    ReplaceOneResult result = knightCollection.ReplaceOne(filter, entidade);
                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Incluir(KnightEntidade knight)
        {
            await _context.knight.InsertOneAsync(knight);
        }

        public async Task<IEnumerable<KnightEntidade>> Obter(string id)
        {
            if (id != "")
            {
                return await _context.knight.Find(x => x.Id.Equals(id)).ToListAsync();
            }
            else
            {
                return await _context.knight.Find(_ => true).ToListAsync();
            }
        }

        public IEnumerable<KnightDto> MapBaseDocToObject()
        {
            FileBaseRota fileBaseRota = new();
            fileBaseRota.FileBaseRotaService();

            var doc = XDocument.Parse(fileBaseRota.LerFileBaseRotaService());
            IEnumerable<KnightDto> result = from r in doc.Descendants("KNIGHT")
                                            select new KnightDto()
                                            {
                                                //Origem = r.Element("ORIGEM").Value.ToString(),
                                                //Destino = r.Element("DESTINO").Value.ToString(),
                                                //Valor = Convert.ToDecimal(r.Element("VALOR").Value),
                                                Id = "0"
                                            };

            return result;
        }

        public async Task<bool> Excluir(string id)
        {
            try
            {
                DeleteResult deleteResult = await _context.knight.DeleteManyAsync(x => x.Id.Equals(id));

                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

            } catch (Exception ex) 
            { 
                throw ex;
            }
        }
    }
}
