using BP.API.Service;

namespace BP.API.Extensions
{
    public static class DependencyContainer
    {
        public static IServiceCollection ServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactService, ContactService>();

            return service;
        }
    }
}
