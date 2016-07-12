using System;
using System.Reflection;

public interface IPerson
{
    string Name { get; }
    int Age { get; }
}

public class Citizen : IPerson
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

public class DefineAnInterfacePerson
{
    public static void Main(string[] args)
    {
        Type personInterface = typeof(Citizen).GetInterface("IPerson");
        PropertyInfo[] properties = personInterface.GetProperties();
        Console.WriteLine(properties.Length);
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        IPerson person = new Citizen(name, age);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}