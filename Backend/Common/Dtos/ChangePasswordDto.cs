using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class ChangePasswordDto
    {
        public string NewPassword { get; set; }
        public int UserId { get; set; }
    }
}
