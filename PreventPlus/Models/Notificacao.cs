using System;
using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class Notificacao
    {
        [Key]
        public int IdNotificacao { get; set; }
        public string TituloNotificacao { get; set; }
        public string DescNotificacao { get; set; }
        public DateTime EnvioNotificacao { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Alerta> Alertas { get; set; }
    }
}