using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Rotas.Dominio.Entidade
{
    [Description("Tabela")]
    [Table("TABELA_KNIGHT", Schema = "KNIGHTS")]
    public class KnightEntidade : EntidadeBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public override decimal Id { get; set; }        
    }
}
