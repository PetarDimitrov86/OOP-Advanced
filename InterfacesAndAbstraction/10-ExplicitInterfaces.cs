using System;

public interface IPerson
{
    string Name { get; }
    int Age { get; }

    string GetName();
}

public interface IResident
{
    string Name { get; }
    string Country { get; }

    string GetName();
}

public class Citizen : IResident, IPerson
{
    private string name;
    private string country;
    private int age;

    public int Age { get; }
    public string Country { get; }

    public Citizen(string name, string country, int age)
    {
        this.name = name;
        this.Country = country;
        this.Age = age;
    }

    string IResident.Name
    {
        get { return this.name; }
    }

    string IPerson.Name
    {
        get { return this.name; }
    }

    string IPerson.GetName()
    {
        return this.name;
    }

    string IResident.GetName()
    {
        return "Mr/Ms/Mrs " + this.name;
    }
}

public class ExplicitInterfaces
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] personInfo = input.Split();
            string name = personInfo[0];
            string country = personInfo[1];
            int age = int.Parse(personInfo[2]);
            Citizen citizen = new Citizen(name, country, age);
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
            input = Console.ReadLine();
        }
    }
}