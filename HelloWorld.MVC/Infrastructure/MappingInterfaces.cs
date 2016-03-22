using AutoMapper;

namespace HelloWorld.MVC.Infrastructure
{
    public interface ICreateMapping<TEntity>
    {
    }

    public interface ICreateCustomMapping
    {
        void CustomMapping(IConfiguration configuration);
    }
}