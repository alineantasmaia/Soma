using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Entidade;

namespace Master.Rotas.Dominio.Interface.Repositorios
{
    public interface IRepositorioKnight
    {
        Task<KnightEntidade> Incluir(KnightEntidade knightEntidade);
        Task<KnightEntidade> Alterar(KnightEntidade knightEntidade);        
        IEnumerable<KnightDto> Obter(string id);        
    }
}
