using System;
using System.Collections.Generic;

public class GenericBox<T>
{
    private T type;
    public static int Counter;

    public GenericBox(T type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        return $"{this.type.GetType().FullName}: {this.type}";
    }

    public static void Compare<T>(List<T> list, T element)
        where T : IComparable<T>
    {
        foreach (var generic in list)
        {
            if (generic.CompareTo(element)> 0)
            {
                Counter++;
            }
        }
    }
}

class GenericCountMethodStrings
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> genericList = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            genericList.Add(input);
        }
        string comparingElement = Console.ReadLine();
        GenericBox<string>.Compare<string>(genericList, comparingElement);
        Console.WriteLine(GenericBox<string>.Counter);
    }
}