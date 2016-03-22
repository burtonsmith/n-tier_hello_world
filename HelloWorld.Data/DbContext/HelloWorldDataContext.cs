using System;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Data.DbContext
{
    public class HelloWorldDataContext: System.Data.Entity.DbContext
    {
        public HelloWorldDataContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<HelloWorldDataContext>());
        }

        public DbSet<Greeting> Greetings { get; set; }
    }
}
