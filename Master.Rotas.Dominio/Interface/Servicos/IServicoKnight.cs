using Master.Rotas.Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
