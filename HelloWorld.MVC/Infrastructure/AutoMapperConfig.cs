using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;

namespace HelloWorld.MVC.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            CreateMappings(types);
            CreateCustomMappings(types);

            Mapper.AssertConfigurationIsValid();
        }

        private static void CreateMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType
                      && i.GetGenericTypeDefinition() == typeof (ICreateMapping<>)
                      && !t.IsAbstract
                      && !t.IsInterface
                select new
                {
                    Entity = i.GetGenericArguments()[0],
                    ViewModel = t
                }).ToList();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Entity, map.ViewModel);
                Mapper.CreateMap(map.ViewModel, map.Entity);
            }
        }

        private static void CreateCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(ICreateCustomMapping).IsAssignableFrom(t)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select (ICreateCustomMapping)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CustomMapping(Mapper.Configuration);
            }
        }
    }
}