using Master.Rotas.Dominio.Entidade;

namespace Master.Rotas.Dominio.Interface.Servicos
{
    public interface IServicoKnight
    {
        Task<IEnumerable<KnightEntidade>> Obter(string id);
        bool Incluir(KnightEntidade knight);
        bool Atualizar(KnightEntidade knight);
        bool Excluir(string id);
    }
}
