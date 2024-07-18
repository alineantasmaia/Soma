using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Entidade;
using Master.Rotas.Dominio.Interface.Repositorios;
using Master.Rotas.Dominio.Interface.Servicos;

namespace Master.Rotas.Dominio.Services
{
    public class ServiceKnights : IServicoKnight
    {
        IRepositorioKnight _repositorioKnight;

        public ServiceKnights(IRepositorioKnight repositorioKnight)
        {
            _repositorioKnight = repositorioKnight;
        }
        public void Incluir(KnightDto knightDto)
        {
            ValidarObjeto(knightDto);
            var tabela = new KnightEntidade();
            tabela = MontarObjetoTabela(tabela, knightDto);
            var retorno = _repositorioKnight.Incluir(tabela).Result;
        }

        public IEnumerable<KnightDto> Obter(string id)
        {
            return _repositorioKnight.Obter(id);
        }

        public void Atualizar(KnightDto knightDto)
        {

        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        private KnightEntidade MontarObjetoTabela(KnightEntidade tabela, KnightDto knightDto)
        {
            return new KnightEntidade() { };
        }

        private void ValidarObjeto(KnightDto knightDto)
        {
            if (knightDto.Id == "")
            {
                throw new Exception("Obrigatório informar a chave id!");
            }
        }
    }
}
