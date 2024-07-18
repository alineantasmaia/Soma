using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Entidade;
using Master.Rotas.Dominio.Interface.Repositorios;
using Master.Rotas.Infra.Servicos;
using System.Xml.Linq;

namespace Master.Rotas.Infra.Dados.Repositorios
{
    public class RepositorioKnight : IRepositorioKnight
    {
        public Task<KnightEntidade> Alterar(KnightEntidade knight)
        {
            throw new NotImplementedException();
        }

        public Task<KnightEntidade> Incluir(KnightEntidade knight)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KnightDto> Obter(string id)
        {
            var result = MapBaseDocToObject().Where(x => x.Id == "0");
            return result;
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


    }
}
