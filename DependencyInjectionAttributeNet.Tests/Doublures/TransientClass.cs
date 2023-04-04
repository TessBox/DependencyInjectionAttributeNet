namespace DependencyInjectionAttributeNet.Tests.Doublures;

public interface ITransientClass
{
    int GetValue();
}

[Transient<ITransientClass>()]
public class TransientClass : ITransientClass
{
    private int _value = 1;

    public int GetValue()
    {
        return _value++;
    }
}
