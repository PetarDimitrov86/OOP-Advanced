using System;
using System.Collections.Generic;
using System.Linq;

interface IBuyer
{
    int Food { get; }
    void BuyFood();
}

interface IGroupable
{
    string Group { get; }
}

interface IBirthday
{
    string Birthdate { get; }

    bool ValidDate(string givenYear);
}

interface IIDable
{
    string ID { get; }
    string ModelName { get; }

    bool validCitizen(string fakeEndID);
}

interface IUnited : IIDable, IBuyer
{
}

public class Citizen : IIDable
{
    public string ID { get; }
    public string ModelName { get; }

    public Citizen(string modelName, string id)
    {
        this.ModelName = modelName;
        this.ID = id;
    }

    public bool validCitizen(string fakeEndID)
    {
        if (this.ID.EndsWith(fakeEndID))
        {
            return false;
        }
        return true;
    }
}

public class Person : Citizen, IBirthday, IUnited
{
    public int Age { get; }
    public string Birthdate { get; }
    public int Food { get; private set; }
    public bool ValidDate(string givenYear)
    {
        if (this.Birthdate.EndsWith(givenYear))
        {
            return true;
        }
        return false;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }

    public Person(string modelName, int age, string id, string birthdate) : base(modelName, id)
    {
        this.Birthdate = birthdate;
        this.Age = age;
    }
}

public class Rebel : IGroupable, IUnited
{
    public string ModelName { get; }
    public int Age { get; }
    public string Birthdate { get; }
    public string Group { get; }
    public string ID { get; }

    public int Food { get; private set; }

    public Rebel(string modelName, int age, string group)
    {
        this.ModelName = modelName;
        this.Age = age;
        this.Group = group;
    }

    public bool validCitizen(string fakeEndID)
    {
        if (this.ID.EndsWith(fakeEndID))
        {
            return false;
        }
        return true;
    }

    public bool ValidDate(string givenYear)
    {
        if (this.Birthdate.EndsWith(givenYear))
        {
            return true;
        }
        return false;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

class FoodShortage
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<IUnited> buyers = new List<IUnited>();
        for (int i = 0; i < n; i++)
        {
            string[] citizenInfo = Console.ReadLine().Split();
            string name = citizenInfo[0];
            int age = int.Parse(citizenInfo[1]);
            if (citizenInfo.Length == 4)
            {
                var citizen = new Person(name, age, citizenInfo[2], citizenInfo[3]);
                buyers.Add(citizen);
            }
            if (citizenInfo.Length == 3)
            {
                var rebel = new Rebel(name, age, citizenInfo[2]);
                buyers.Add(rebel);
            }
        }
        string personToFeed = Console.ReadLine();
        while (personToFeed != "End")
        {
            if (buyers.Any(x=>x.ModelName == personToFeed))
            {
                buyers.First(x => x.ModelName == personToFeed).BuyFood();
            }
            personToFeed = Console.ReadLine();
        }
        int totalFoodBought = 0;
        foreach (var buyer in buyers)
        {
            totalFoodBought += buyer.Food;
        }
        Console.WriteLine(totalFoodBought);
    }
}