using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class UpdateModelDto<T>
    {
        public T OldModel { get; set; }
        public T NewModel { get; set; }
    }
}
