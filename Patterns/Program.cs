namespace Patterns;

class Program
{
    static void Main(string[] args)
    {
        Dealership dealership = new Dealership();

        Buyer buyer = new Buyer();
        buyer.SeeCars(dealership);
        Console.Read();
    }
}