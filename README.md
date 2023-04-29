# DependencyInjectionAttributeNet
Framework to able the dependency injection with attribute.

## Installation

dotnet add package DependencyInjectionAttributeNet

## Setup 

```csharp
var services = new ServiceCollection();
services.AddFromEntryAssembly();  // Search on the entry assembly
 
services.AddFromAssembly(GetType().Assembly); // Or specify the assembly
var serviceProvider = services.BuildServiceProvider();
```

## Usage

Singleton :
```csharp
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

```

Transient :
```csharp
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


```

# Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

# License

[MIT](https://choosealicense.com/licenses/mit/)