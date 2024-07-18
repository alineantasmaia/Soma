using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Entidade;

namespace Master.Rotas.Dominio.Interface.Repositorios
{
    public interface IRepositorioKnight
    {
        Task Incluir(KnightEntidade knightEntidade);
        Task<bool> Alterar(KnightEntidade knightEntidade);        
        Task<IEnumerable<KnightEntidade>> Obter(string id);
        Task<bool> Excluir(string id);
    }
}
