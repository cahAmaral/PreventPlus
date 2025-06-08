using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreventPlus.Models
{
    public class Usuario
    { 
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime UsuarioCriado { get; set; }
        public int IdRegiao { get; set; }

        public Regiao Regiao { get; set; }
        public ICollection<Checklist> Checklists { get; set; }
        public ICollection<Dica> Dicas { get; set; }
        public ICollection<Kit> Kits { get; set; }
        public ICollection<Notificacao> Notificacoes { get; set; }
        public ICollection<LocalFavorito> LocaisFavoritos { get; set; }
    }
}