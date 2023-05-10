namespace Patterns;

class Buyer
{
    public void SeeCars(Dealership dealership)
    {
        ICarIterator iterator = dealership.CreateNumerator();
        while(iterator.HasNext())
        {
            Car car = iterator.Next();
            car.ShowComponents();
        }
    }
}
interface ICarIterator
{
    bool HasNext();
    Car Next();
}

interface ICarNumerable
{
    ICarIterator CreateNumerator();
    int Count { get; }
    Car this[int index] { get; }
}

class Dealership : ICarNumerable
{
    private Car[] cars;

    public Dealership()
    {
        cars = new Car[]
        {
            new Car(new RussianFactory()),
            new Car(new JapanFactory()),
            new Car(new RussianFactory())
        };
    }

    public int Count => cars.Length;

    public Car this[int index] => cars[index];

    public ICarIterator CreateNumerator()
    {
        return new DealershipNumerator(this);
    }
}

class DealershipNumerator : ICarIterator
{
    ICarNumerable aggregate;
    int index = 0;

    public DealershipNumerator(ICarNumerable a)
    {
        aggregate = a;
    }

    public bool HasNext()
    {
        return index < aggregate.Count;
    }

    public Car Next()
    {
        return aggregate[index++];
    }
}