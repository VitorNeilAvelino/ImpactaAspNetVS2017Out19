using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet.Capitulo03.Portfolio.Models
{
    public class ContatoViewModel
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}