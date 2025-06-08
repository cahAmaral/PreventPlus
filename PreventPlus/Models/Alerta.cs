using System;
using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class Alerta
    {
        [Key]
        public int IdAlerta { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdTipoDesastre { get; set; }
        public TipoDesastre TipoDesastre { get; set; }
    }
}