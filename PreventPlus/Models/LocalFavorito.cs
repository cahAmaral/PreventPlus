using System.ComponentModel.DataAnnotations;
namespace PreventPlus.Models
{
    public class LocalFavorito
    {
        [Key]
        public int IdFav { get; set; }
        public int IdUsuario { get; set; }
        public int IdLocal { get; set; }

        public Usuario Usuario { get; set; }
        public LocalSeguro LocalSeguro { get; set; }
    }
}