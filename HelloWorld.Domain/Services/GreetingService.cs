using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Repositories;
using HelloWorld.Domain.ServiceInterfaces;

namespace HelloWorld.Domain.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly IRepository<Greeting> _greetingRepository;

        public GreetingService(IRepository<Greeting> greetingRepository)
        {
            _greetingRepository = greetingRepository;
        }

        public Greeting Insert(Greeting entity)
        {
            if(entity == null)
                throw new ArgumentException(nameof(entity));

            return _greetingRepository.Insert(entity);
        }

        public void Update(Greeting entity)
        {
            _greetingRepository.Update(entity);
        }

        public void Delete(int id)
        {
            if(id == default(int))
                throw new ArgumentNullException(nameof(id));

            _greetingRepository.Delete(id);
        }

        public Greeting GetById(int id)
        {
            if (id == default(int))
                throw new ArgumentNullException(nameof(id));

            return _greetingRepository.GetById(id);
        }

        public IEnumerable<Greeting> Data => _greetingRepository.Data;
    }
}
