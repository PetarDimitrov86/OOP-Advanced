using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public class NameLenghtComperator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = 0;
            if (x.Name.Length.CompareTo(y.Name.Length) != 0)
            {
                result = x.Name.Length.CompareTo(y.Name.Length);
            }
            if (result == 0)
            {
                result = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
            }
            return result;
        }
    }

    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
;    }
}

public class StrategyPattern
{
    static void Main()
    {
        SortedSet<Person> nameSort = new SortedSet<Person>(new Person.NameLenghtComperator());
        SortedSet<Person> ageSort = new SortedSet<Person>(new Person.AgeComparer());
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personInfo = Console.ReadLine().Split();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            Person person = new Person(name, age);
            nameSort.Add(person);
            ageSort.Add(person);
        }
        foreach (var person in nameSort)
        {
            Console.WriteLine(person);
        }
        foreach (var person in ageSort)
        {
            Console.WriteLine(person);
        }
    }
}