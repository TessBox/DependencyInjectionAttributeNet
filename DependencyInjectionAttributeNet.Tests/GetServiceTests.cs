using DependencyInjectionAttributeNet.Tests.Doublures;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionAttributeNet.Tests;

public class TransientTests
{
    [Fact]
    public void Transient_Success()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddFromAssembly(GetType().Assembly);
        var serviceProvider = services.BuildServiceProvider();

        // act
        var instance1 = serviceProvider.GetService<ITransientClass>();
        var instance2 = serviceProvider.GetService<ITransientClass>();

        // assert
        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.Equal(1, instance1.GetValue());
        Assert.Equal(1, instance2.GetValue());
    }

    [Fact]
    public void Singleton_Success()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddFromAssembly(GetType().Assembly);
        var serviceProvider = services.BuildServiceProvider();

        // act
        var instance1 = serviceProvider.GetService<ISingletonClass>();
        var instance2 = serviceProvider.GetService<ISingletonClass>();

        // assert
        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.Equal(1, instance1.GetValue());
        Assert.Equal(2, instance2.GetValue());
    }

    [Fact]
    public void ServiceBuilderAttribute_Success()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddFromAssembly(GetType().Assembly);
        var serviceProvider = services.BuildServiceProvider();

        // act
        var instance1 = serviceProvider.GetService<ServiceBuilderClass>();
        var instance2 = serviceProvider.GetService<ServiceBuilderClass>();

        // assert
        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.Equal(1, instance1.GetValue());
        Assert.Equal(2, instance2.GetValue());
    }
}
