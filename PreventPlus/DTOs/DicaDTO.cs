namespace PreventPlus.DTOs
{
    public class DicaDTO
    {
        public int IdDica { get; set; }
        public string TituloDica { get; set; }
        public string ConteudoDica { get; set; }
        public string TipoDica { get; set; }
        public DateTime CriacaoDica { get; set; }
        public int IdDesastre { get; set; }
        public int IdUsuario { get; set; }
    }
}