# 5 design patterns you have to know

## STRATEGY

The Strategy Design Pattern allows defining a family of algorithms, encapsulating each one, and making them interchangeable.
This pattern enables selecting an algorithm's behavior at runtime without altering the objects that use it.
It's particularly useful when different behaviors are needed in different situations, allowing for flexible and reusable code.
The pattern involves three key components: Context, which uses a strategy; Strategy,
which defines a common interface for algorithms; and Concrete Strategies, which implement specific algorithms.

```c#
// Strategy interface
public interface ICompressionStrategy
{
    void Compress(string filePath);
}

// Concrete strategies
public class ZipCompression : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"{filePath} compressed using ZIP.");
    }
}

public class RarCompression : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"{filePath} compressed using RAR.");
    }
}

// Context
public class FileCompressor
{
    private readonly ICompressionStrategy _compressionStrategy;

    public FileCompressor(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void CompressFile(string filePath)
    {
        _compressionStrategy.Compress(filePath);
    }
}

// Usage
class Program
{
    static void Main()
    {
        var filePath = "example.txt";

        var zipCompressor = new FileCompressor(new ZipCompression());
        zipCompressor.CompressFile(filePath);

        var rarCompressor = new FileCompressor(new RarCompression());
        rarCompressor.CompressFile(filePath);
    }
}

```

## DECORATOR

The Decorator Design Pattern allows behavior to be added to individual objects, dynamically, without affecting the behavior of other objects from the same class. This pattern is useful when you want to extend the functionality of an object in a flexible and reusable way.

It involves:

Component: Defines the common interface for objects that can have responsibilities added dynamically.
ConcreteComponent: The basic object that can have additional responsibilities.
Decorator: Wraps the component and adds extra behavior.
ConcreteDecorator: Adds specific behavior to the component.

```c#
// Component interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete component
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";

    public double GetCost() => 5.0;
}

// Base decorator
public abstract class CoffeeDecorator : ICoffee
{
    protected readonly ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();

    public virtual double GetCost() => _coffee.GetCost();
}

// Concrete decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Milk";

    public override double GetCost() => _coffee.GetCost() + 1.5;
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Sugar";

    public override double GetCost() => _coffee.GetCost() + 0.5;
}

// Usage
class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");
    }
}

```

## OBSERVER

The Observer Design Pattern defines a one-to-many relationship between objects, so that when one object (the subject) changes state, all its dependents (observers) are notified and updated automatically. This pattern is useful when changes in one object need to be reflected in others without tightly coupling them.

It involves:

Subject: Maintains a list of observers and notifies them of any state changes.
Observer: Defines an interface for receiving updates.
ConcreteSubject: Implements the subject and sends notifications to observers.
ConcreteObserver: Implements the observer and updates its state when notified by the subject.

```c#
// Observer interface
public interface IObserver
{
    void Update(string message);
}

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete subject
public class WeatherStation : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private string _weatherUpdate;

    public void SetWeatherUpdate(string update)
    {
        _weatherUpdate = update;
        Notify();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_weatherUpdate);
        }
    }
}

// Concrete observers
public class PhoneDisplay : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Phone Display: Weather update received - {message}");
    }
}

public class WindowDisplay : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Window Display: Weather update received - {message}");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var weatherStation = new WeatherStation();

        var phoneDisplay = new PhoneDisplay();
        var windowDisplay = new WindowDisplay();

        weatherStation.Attach(phoneDisplay);
        weatherStation.Attach(windowDisplay);

        weatherStation.SetWeatherUpdate("Sunny, 25°C");

        weatherStation.SetWeatherUpdate("Rainy, 18°C");
    }
}

```

## SINGLETON

The Singleton Design Pattern ensures that a class has only one instance and provides a global point of access to that instance. This pattern is useful when exactly one object is needed to coordinate actions across the system.

Key points of a Singleton:

A private constructor prevents other classes from instantiating it.
A static method provides access to the single instance.
The instance is typically created lazily, meaning it's created only when needed.

```c#
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    // Private constructor to prevent direct instantiation
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }

    // Public method to provide access to the instance
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock) // Ensure thread safety
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    // Example method to demonstrate functionality
    public void DoSomething()
    {
        Console.WriteLine("Singleton is doing something.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var singleton1 = Singleton.Instance;
        singleton1.DoSomething();

        var singleton2 = Singleton.Instance;
        Console.WriteLine(singleton1 == singleton2); // Output: True (same instance)
    }
}

```

## FACADE

The Facade Design Pattern provides a simplified interface to a complex system of classes, libraries, or frameworks. It helps hide the complexity of subsystems by offering a higher-level interface. The pattern is useful when dealing with large systems, making them easier to use and understand by offering a single entry point for different functionalities.

Key Points:
Facade: Simplifies the interface and delegates tasks to the relevant subsystems.
Subsystems: Perform the actual work and are hidden from the client.

```c#
// Subsystem 1
public class OrderService
{
    public void PlaceOrder(string product)
    {
        Console.WriteLine($"Order placed for {product}.");
    }
}

// Subsystem 2
public class PaymentService
{
    public void ProcessPayment(string product)
    {
        Console.WriteLine($"Payment processed for {product}.");
    }
}

// Subsystem 3
public class ShippingService
{
    public void ShipProduct(string product)
    {
        Console.WriteLine($"Product {product} shipped.");
    }
}

// Facade
public class ECommerceFacade
{
    private readonly OrderService _orderService;
    private readonly PaymentService _paymentService;
    private readonly ShippingService _shippingService;

    public ECommerceFacade()
    {
        _orderService = new OrderService();
        _paymentService = new PaymentService();
        _shippingService = new ShippingService();
    }

    public void CompleteOrder(string product)
    {
        _orderService.PlaceOrder(product);
        _paymentService.ProcessPayment(product);
        _shippingService.ShipProduct(product);
        Console.WriteLine($"Order for {product} completed.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        var facade = new ECommerceFacade();

        facade.CompleteOrder("Laptop");
    }
}

```
