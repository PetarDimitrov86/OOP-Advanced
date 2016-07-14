using System;
using System.Collections.Generic;

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
        Console.WriteLine(Compare(genericList, comparingElement));
    }

    public static int Compare<T>(List<T> list, T element)
      where T : IComparable<T>
    {
        int counter = 0;
        foreach (var generic in list)
        {
            if (generic.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
}