using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendEcom.Models
{
    public class LoginData
    {
        public string Email { get; set; }
       [Display (Name = "Password")]
        public string Upassword { get; set; }
    }
}
