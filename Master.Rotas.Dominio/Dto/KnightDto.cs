namespace Master.Rotas.Dominio.Dto
{
    public class KnightDto
    {        
        public string? Id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public decimal birthday { get; set; }
        public List<WeaponsDto> weapons { get; set; }
        public List<AttributesDto> atributes { get; set; }
        public decimal keyAttribute { get { return new AttributesDto().strenght; }}
    }
}
