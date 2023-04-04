using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionAttributeNet.Tests.Doublures;

public class ServiceBuilder : IServiceBuilder
{
    public void AddServices(IServiceCollection services)
    {
        services.AddSingleton(new ServiceBuilderClass());
    }
}

[ServiceBuilder<ServiceBuilder>]
public class ServiceBuilderClass
{
    private int _value = 1;

    public int GetValue()
    {
        return _value++;
    }
}
