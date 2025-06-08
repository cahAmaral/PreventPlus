using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class Kit
    {
        [Key]
        public int IdKit { get; set; }
        public string ItemKit { get; set; }
        public int QtdItem { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}