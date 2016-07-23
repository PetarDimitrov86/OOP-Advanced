using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public string Name { get; }
    public int Age { get; }
    public string Town { get; }

    public Person(string name, int age, string town)
    {
       this.Name = name;
       this.Age = age;
       this.Town = town;
    }

    public int CompareTo(Person other)
    {
        int comparison = 0;
        if (this.Name.CompareTo(other.Name) != 0)
        {
            comparison = this.Name.CompareTo(other.Name);
        }
        if (this.Age.CompareTo(other.Age) != 0)
        {
            comparison = this.Age.CompareTo(other.Age);
        }
        if (this.Town.CompareTo(other.Town) != 0)
        {
            comparison = this.Town.CompareTo(other.Town);
        }
        return comparison;
    }
}

public class ComparingObjects
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] personInfo = input.Split();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string town = personInfo[2];
            Person person = new Person(name, age, town);
            people.Add(person);
            input = Console.ReadLine();
        }
        int personIndex = int.Parse(Console.ReadLine()) - 1;
        Person desiredPerson = people[personIndex];
        int equalPeople = 0;
        foreach (var person in people)
        {
            if (person.CompareTo(desiredPerson) == 0)
            {
                equalPeople++;
            }
        }
        if (equalPeople == 1)
        {
            Console.WriteLine("No matches");
            return;
        }
        Console.WriteLine($"{equalPeople} {people.Count-equalPeople} {people.Count}");
    }
}