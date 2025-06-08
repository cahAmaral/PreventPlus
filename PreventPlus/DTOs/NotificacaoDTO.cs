namespace PreventPlus.DTOs
{
    public class NotificacaoDTO
    {
        public int IdNotificacao { get; set; }
        public string TituloNotificacao { get; set; }
        public string DescNotificacao { get; set; }
        public DateTime EnvioNotificacao { get; set; }
        public int IdUsuario { get; set; }
    }
}