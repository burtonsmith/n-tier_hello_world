using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class Greeting : BaseEntity
    {
        public string Description { get; set; }
    }
}
