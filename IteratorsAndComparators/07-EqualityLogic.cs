using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }
    public int Age { get; }

    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = 0;
            if (x.Name.CompareTo(y.Name) != 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            if (x.Age.CompareTo(y.Age) != 0)
            {
                return x.Age.CompareTo(y.Age);
            }
            return result;
        }
    }

    public override int GetHashCode()
    {
        int lettersSum = 0;
        for (int i = 0; i < this.Name.Length; i++)
        {
            lettersSum += this.Name[i];
        }
        return lettersSum * this.Age;
    }

    public int CompareTo(Person other)
    {
        int result = 0;
        if (this.Name.CompareTo(other.Name) != 0)
        {
            return this.Name.CompareTo(other.Name);
        }
        if (this.Age.CompareTo(other.Age) != 0)
        {
            return this.Age.CompareTo(other.Age);
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        var newObject = obj as Person;

        return this.GetHashCode() == newObject.GetHashCode();
    }
}

public class EqualityLogic
{
    static void Main()
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personInfo = Console.ReadLine().Split();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            Person person = new Person(name, age);
            sortedSet.Add(person);
            hashSet.Add(person);
        }
        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}
