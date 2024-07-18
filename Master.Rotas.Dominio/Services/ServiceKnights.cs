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
        public bool Incluir(KnightEntidade knightDto)
        {
            ValidarObjeto(knightDto);            
            return _repositorioKnight.Incluir(knightDto).IsCompletedSuccessfully;
        }

        public Task<IEnumerable<KnightEntidade>> Obter(string id)
        {
            return _repositorioKnight.Obter(id);
        }

        public bool Atualizar(KnightEntidade knightDto)
        {
            return _repositorioKnight.Alterar(knightDto).IsCompletedSuccessfully;
        }

        public bool Excluir(string id)
        {
            return _repositorioKnight.Excluir(id).IsCompletedSuccessfully;
        }

        private void ValidarObjeto(KnightEntidade knightDto)
        {
            if (knightDto.Id.Equals(null))
            {
                throw new Exception("Obrigatório informar a chave id!");
            }
        }
    }
}
