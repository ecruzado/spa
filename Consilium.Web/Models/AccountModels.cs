using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consilium.Web.Models
{

    public class LogOnModel
    {
        [Required]
        [Display(Name="Usuario")]
        [StringLength(50, ErrorMessage = "El {0} no debe exeder los 50 caracteres")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "El {0} no debe exeder los 50 caracteres")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}