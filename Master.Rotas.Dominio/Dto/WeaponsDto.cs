namespace Master.Rotas.Dominio.Dto
{
    public class WeaponsDto
    {
        private bool _equipped;

        public string name { get; set; }
        public string mod { get; set; }
        public decimal attr { get { return new AttributesDto().strenght; } }
        public bool equipped { get { return _equipped; } set { _equipped = true; } }


    }
}
