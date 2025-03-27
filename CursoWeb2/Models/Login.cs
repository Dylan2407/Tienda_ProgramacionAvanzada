using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoWeb2.Models
{
    public class Login
    {

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Correo { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Contraseña { set; get; }

        [Display(Name = "Recordar mi cuenta")]
        public bool Recordar { set; get; }

    }
}