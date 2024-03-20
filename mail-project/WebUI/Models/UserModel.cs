using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Models
{
    public class UserModel
    {
        
    }

    public class UserLoginModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

}