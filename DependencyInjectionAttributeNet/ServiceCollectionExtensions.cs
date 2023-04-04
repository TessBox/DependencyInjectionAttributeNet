using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionAttributeNet;

public static class ServiceCollectionExtensions
{
    public static void AddFromEntryAssembly(this IServiceCollection services)
    {
        var assembly =
            Assembly.GetEntryAssembly() ?? throw new Exception("Entry assembly not found");
        AddServices(new[] { assembly }, services);
        AddBuilder(new[] { assembly }, services);
    }

    public static void AddFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        AddServices(new[] { assembly }, services);
        AddBuilder(new[] { assembly }, services);
    }

    private static void AddServices(Assembly[] assemblies, IServiceCollection services)
    {
        var servicesToRegister = assemblies
            .SelectMany(t => t.GetTypes())
            .Select(t => new { ImplementationType = t, Attribute = GetServiceAttribute(t) })
            .Where(t => t.Attribute != null);

        foreach (var service in servicesToRegister)
        {
            if (service.Attribute == null)
                continue;

            // singleton
            if (service.Attribute.Lifetime == Lifetime.Singleton)
            {
                services.AddSingleton(service.Attribute.ServiceType, service.ImplementationType);
                continue;
            }

            // transient
            services.AddTransient(service.Attribute.ServiceType, service.ImplementationType);
        }
    }

    private static void AddBuilder(Assembly[] assemblies, IServiceCollection services)
    {
        var servicesToBuild = assemblies
            .SelectMany(t => t.GetTypes())
            .Select(t => t.GetCustomAttribute<ServiceBuilderAttribute>())
            .Where(t => t != null);

        foreach (var service in servicesToBuild)
        {
            if (service == null)
                continue;

            if (Activator.CreateInstance(service.BuilderType) is not IServiceBuilder builder)
                throw new NullReferenceException(service.BuilderType.Name);

            builder.AddServices(services);
        }
    }

    private static ServiceAttribute? GetServiceAttribute(Type type)
    {
        return type.GetCustomAttribute<ServiceAttribute>();
    }
}
