using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class ProjeUser : IdentityUser<int>
    {
        public string UserAdi { get; set; }
        public string UserSoyadi { get; set; }
        public DateTime UserRegisterDate { get; set; }
    }
}