namespace PreventPlus.DTOs
{
    public class HistoricoRiscoDTO
    {
        public int IdHistorico { get; set; }
        public int HistChuva { get; set; }
        public int HistUmidade { get; set; }
        public int HistTemp { get; set; }
        public int HistAlerta { get; set; }
        public string HistImpacto { get; set; }
        public int IdRegiao { get; set; }
    }
}