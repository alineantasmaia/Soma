using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Collections.Generic;


namespace Master.Rotas.Dominio.Entidade
{
    public class EntidadeBase
    {   
        public virtual decimal Id { get; set; }

        [NotMapped]
        public List<string> Notificacoes { get; set; }

        public bool Valido<T, T2>(T validacao, T2 entidade) where T : AbstractValidator<T2> where T2 : EntidadeBase
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid) return true;

            Notificacoes = validador.Errors.Select(p => p.ErrorMessage).ToList();

            return false;
        }
    }
}
