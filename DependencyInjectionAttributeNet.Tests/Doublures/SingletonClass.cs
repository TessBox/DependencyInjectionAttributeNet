namespace DependencyInjectionAttributeNet.Tests.Doublures;

public interface ISingletonClass
{
    int GetValue();
}

[Singleton<ISingletonClass>()]
public class SingletonClass : ISingletonClass
{
    private int _value = 1;

    public int GetValue()
    {
        return _value++;
    }
}
