using Master.Rotas.Dominio.Dto;
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
        public string name { get; set; }
        public string nickname { get; set; }
        public decimal birthday { get; set; }
        public List<WeaponsDto> weapons { get; set; }
        public List<AttributesDto> atributes { get; set; }
        public decimal keyAttribute { get { return new AttributesDto().strenght; } }
    }
}
