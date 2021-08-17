using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class AuthenticationDto
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; } //todo
    }
}
