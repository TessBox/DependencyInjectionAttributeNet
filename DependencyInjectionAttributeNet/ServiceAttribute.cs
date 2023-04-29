namespace DependencyInjectionAttributeNet;

/// <summary>
/// Attribute to define the interface and the Lifetime of the service
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ServiceAttribute : Attribute
{
    public ServiceAttribute(Type interfaceType, Lifetime lifetime)
    {
        InterfaceType = interfaceType;
        Lifetime = lifetime;
    }

    /// <summary>
    /// Type of the interface for this service
    /// </summary>
    public Type InterfaceType { get; }

    /// <summary>
    /// Lifetime
    /// </summary>
    /// <value></value>
    public Lifetime Lifetime { get; }
}

[AttributeUsage(AttributeTargets.Class)]
public class ServiceAttribute<TService> : ServiceAttribute
{
    public ServiceAttribute(Lifetime lifetime)
        : base(typeof(TService), lifetime) { }
}

[AttributeUsage(AttributeTargets.Class)]
public class TransientAttribute<TService> : ServiceAttribute
{
    public TransientAttribute()
        : base(typeof(TService), Lifetime.Transient) { }
}

[AttributeUsage(AttributeTargets.Class)]
public class SingletonAttribute<TService> : ServiceAttribute
{
    public SingletonAttribute()
        : base(typeof(TService), Lifetime.Singleton) { }
}

public enum Lifetime
{
    Singleton,
    Transient
}
