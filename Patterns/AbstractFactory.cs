namespace Patterns;

public interface IEngine
{
    public void ReleaseEngine();
}

public interface IWheels
{
    public void ReleaseWheels();
}

public class JapanEngine : IEngine
{
    public void ReleaseEngine()
    {
        Console.WriteLine("японский двигатель");
    }
}

public class RussianEngine : IEngine
{
    public void ReleaseEngine()
    {
        Console.WriteLine("русский двигатель");
    }
}

public class JapanWheels : IWheels
{
    public void ReleaseWheels()
    {
        Console.WriteLine("японские колёса");
    }
}

public class RussianWheels : IWheels
{
    public void ReleaseWheels()
    {
        Console.WriteLine("русские колёса");
    }
}

public interface ICarFactory
{
    public IEngine CreateEngine();
    public IWheels CreateWheels();
}

public class RussianFactory : ICarFactory
{
    public IEngine CreateEngine() => new RussianEngine();

    public IWheels CreateWheels() => new RussianWheels();
}

public class JapanFactory : ICarFactory
{
    public IEngine CreateEngine() => new JapanEngine();

    public IWheels CreateWheels() => new JapanWheels();
}

class Car
{
    private IEngine engine;
    private IWheels wheels;

    public Car(ICarFactory factory)
    {
        engine = factory.CreateEngine();
        wheels = factory.CreateWheels();
    }

    public void ShowComponents()
    {
        engine.ReleaseEngine();
        wheels.ReleaseWheels();
    }
}