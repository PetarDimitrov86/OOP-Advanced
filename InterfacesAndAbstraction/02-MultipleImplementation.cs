using System;
using System.Reflection;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
}

public interface IIdentifiable
{
    string ID { get; }
}

public interface IBirthable
{
    string Birthdate { get; }
}

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string ID { get; }
    public string Birthdate { get; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.ID = ID;
        this.Birthdate = birthdate;
    }
}

public class MultipleImplementation
{
    public static void Main(string[] args)
    {
        Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
        Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
        PropertyInfo[] properties = identifiableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        properties = birthableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();
        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);
    }
}