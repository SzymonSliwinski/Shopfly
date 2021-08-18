using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.Token
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}
