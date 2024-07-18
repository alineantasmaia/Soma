using Master.Rotas.Dominio.Dto;

namespace Master.Rotas.Dominio.Interface.Servicos
{
    public interface IServicoKnight
    {        
        IEnumerable<KnightDto> Obter(string id);
        void Incluir(KnightDto knight);
        void Atualizar(KnightDto knight);
        void Excluir(string id);      

    }
}
