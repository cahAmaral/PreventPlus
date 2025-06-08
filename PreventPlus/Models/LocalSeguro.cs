using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class LocalSeguro
    {
        [Key]
        public int IdLocal { get; set; }
        public string NomeLocal { get; set; }
        public string EnderecoLocal { get; set; }
        public string TipoLocal { get; set; }

        public ICollection<LocalFavorito> LocaisFavoritos { get; set; }
    }
}