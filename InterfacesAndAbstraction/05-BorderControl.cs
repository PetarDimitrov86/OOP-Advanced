using System;
using System.Collections.Generic;

interface IIDable
{
    string ID { get; }
    string ModelName { get; }

    bool validCitizen(string fakeEndID);
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

public class Person : Citizen
{
    public int Age { get; }

    public Person(string modelName, int age, string id) : base(modelName, id)
    {
        this.Age = age;
    }
}

public class Robot : Citizen
{
    public string ID { get; }
    public string ModelName { get; }

    public Robot(string modelName, string id) : base(modelName, id)
    {
    }
}

public class BorderControl
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Citizen> citizens = new List<Citizen>();
        while (input!="End")
        {
            string[] citizenInfo = input.Split();
            int inputLength = citizenInfo.Length;
            string nameModel = citizenInfo[0];
            string ID = citizenInfo[citizenInfo.Length - 1];
            switch (inputLength)
            {
                case 2:
                    Robot robot = new Robot(nameModel, ID);
                    citizens.Add(robot);
                    break;
                case 3:
                    int age = int.Parse(citizenInfo[1]);
                    Person person = new Person(nameModel, age, ID);
                    citizens.Add(person);
                    break;
            }

            input = Console.ReadLine();
        }
        string fakeIDEnding = Console.ReadLine();
        foreach (var citizen in citizens)
        {
            if (!citizen.validCitizen(fakeIDEnding))
            {
                Console.WriteLine(citizen.ID);
            }
        }
    }
}