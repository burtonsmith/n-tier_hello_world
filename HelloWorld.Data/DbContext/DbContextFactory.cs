using System.Data.Entity.Infrastructure;
using System.Configuration;

namespace HelloWorld.Data.DbContext
{
    public class DbContextFactory : IDbContextFactory<HelloWorldDataContext>
    {
        public HelloWorldDataContext Create()
        {
            return new HelloWorldDataContext(ConfigurationManager.ConnectionStrings["HelloWorldConnection"].ToString());
        }
    }
}
