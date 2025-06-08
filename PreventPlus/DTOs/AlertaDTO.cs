namespace PreventPlus.DTOs
{
    public class AlertaDTO
    {
        public int IdAlerta { get; set; }
        public string MensagemAlerta { get; set; }
        public string TipoAlerta { get; set; }
        public DateTime CriacaoAlerta { get; set; }
        public int IdNotificacao { get; set; }
    }
}