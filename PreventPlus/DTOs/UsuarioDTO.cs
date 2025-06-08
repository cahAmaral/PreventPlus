namespace PreventPlus.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime UsuarioCriado { get; set; }
        public int IdRegiao { get; set; }
    }
}