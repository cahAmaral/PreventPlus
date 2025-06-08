using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class TipoDesastre
    { 
        [Key]
        public int IdDesastre { get; set; }
        public string Descricao { get; set; }

        public ICollection<Dica> Dicas { get; set; }
    }
}