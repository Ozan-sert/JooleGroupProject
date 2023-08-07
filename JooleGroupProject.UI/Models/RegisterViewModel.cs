using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooleGroupProject.UI.Models
{
    public class RegisterViewModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Address Required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(100, ErrorMessage = "Password should be less than 100 characters.")]
        [MinLength(5, ErrorMessage = "Password should be at least 5 characters.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Must be consistent with Password.")]
        public string ConfirmPassword { get; set; }
    }
}