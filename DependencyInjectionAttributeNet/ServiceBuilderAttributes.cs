using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionAttributeNet;

[AttributeUsage(AttributeTargets.Class)]
public class ServiceBuilderAttribute : Attribute
{
    public ServiceBuilderAttribute(Type builderType)
    {
        BuilderType = builderType;
    }

    public Type BuilderType { get; }
}

[AttributeUsage(AttributeTargets.Class)]
public class ServiceBuilderAttribute<TBuilder> : ServiceBuilderAttribute
    where TBuilder : IServiceBuilder
{
    public ServiceBuilderAttribute()
        : base(typeof(TBuilder)) { }
}

public interface IServiceBuilder
{
    void AddServices(IServiceCollection services);
}
