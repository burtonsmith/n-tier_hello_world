using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Repositories;

namespace HelloWorld.Domain.ServiceInterfaces
{
    public interface IGreetingService : IRepository<Greeting>
    {
    }
}
