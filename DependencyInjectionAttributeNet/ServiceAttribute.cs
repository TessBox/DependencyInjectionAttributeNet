namespace DependencyInjectionAttributeNet;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ServiceAttribute : Attribute
{
    public ServiceAttribute(Type serviceType, Lifetime lifetime)
    {
        ServiceType = serviceType;
        Lifetime = lifetime;
    }

    public Type ServiceType { get; }

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
