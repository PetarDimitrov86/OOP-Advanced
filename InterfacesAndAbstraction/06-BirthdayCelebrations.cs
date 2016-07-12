using System;
using System.Collections.Generic;

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

public class Person : Citizen, IBirthday
{
    public int Age { get; }
    public string Birthdate { get; }
    public bool ValidDate(string givenYear)
    {
        if (this.Birthdate.EndsWith(givenYear))
        {
            return true;
        }
        return false;
    }

    public Person(string modelName, int age, string id, string birthdate) : base(modelName, id)
    {
        this.Birthdate = birthdate;
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

public class Pet : IBirthday
{
    public string Name { get; }
    public string Birthdate { get; }
    public bool ValidDate(string givenYear)
    {

        if (this.Birthdate.EndsWith(givenYear))
        {
            return true;
        }
        return false;
    }

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
}

class BirthdayCelebrations
{
    static void Main(string[] args)
    {
        List<IBirthday> birthdayObjects = new List<IBirthday>();
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] objectInfo = input.Split();
            string type = objectInfo[0];
            switch (type.ToLower())
            {
                case "citizen":
                    string personName = objectInfo[1];
                    int age = int.Parse(objectInfo[2]);
                    string ID = objectInfo[3];
                    string birthday = objectInfo[4];
                    Person citizen = new Person(personName,age,ID,birthday);
                    birthdayObjects.Add(citizen);
                    break;
                case "robot":
                    break;
                case "pet":
                    string dogName = objectInfo[1];
                    string birthdate = objectInfo[2];
                    Pet pet = new Pet(dogName, birthdate);
                    birthdayObjects.Add(pet);
                    break;
            }
            input = Console.ReadLine();
        }
        string yearFilter = Console.ReadLine();
        foreach (var birthdayObject in birthdayObjects)
        {
            if (birthdayObject.ValidDate(yearFilter))
            {
                Console.WriteLine(birthdayObject.Birthdate);
            }
        }
    }
}