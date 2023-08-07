using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace JooleGroupProject.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name or email address required.")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }
    }
}