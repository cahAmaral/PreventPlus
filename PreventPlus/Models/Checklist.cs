using System.ComponentModel.DataAnnotations;
namespace PreventPlus.Models
{
    public class Checklist
    {
        [Key]
        public int IdChecklist { get; set; }
        public string TituloChecklist { get; set; }
        public string DescricaoChecklist { get; set; }
        public string StatusChecklist { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}