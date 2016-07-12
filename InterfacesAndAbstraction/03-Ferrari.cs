using System;

public interface ICar
{
    string UseBrakes();

    string PushGas();
}

public class Ferrari : ICar
{
    private string name;

    public Ferrari(string name)
    {
        this.Name = name;
    }

    public string Name { get; }
    public string Model { get { return "488-Spider"; } }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }
}

public class Pr3Ferrari
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        Ferrari ferrari = new Ferrari(name);
        Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.PushGas()}/{ferrari.Name}");

        string ferrariName = typeof(Ferrari).Name;
        string iCarInterfaceName = typeof(ICar).Name;

        bool isCreated = typeof(ICar).IsInterface;
        if (!isCreated)
        {
            throw new Exception("No interface ICar was created");
        }
    }
}