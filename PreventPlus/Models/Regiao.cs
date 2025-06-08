using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class Regiao
    {
        [Key]
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public string EstadoRegiao { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<HistoricoRisco> HistoricosRisco { get; set; }
    }
}