using Scrutor;

namespace Project.Byte.Bank_.Repository
{
    public class NativeInjector
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            var selector = new TypeSourceSelector();

            selector.FromCallingAssembly()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithTransientLifetime();

            selector.Populate(services, RegistrationStrategy.Append);

            return services;
        }

        //internal static void RegisterServices()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
