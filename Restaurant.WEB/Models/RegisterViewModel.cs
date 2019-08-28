using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.WEB.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Rut Usuario")]
        public string Rut { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]        
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}