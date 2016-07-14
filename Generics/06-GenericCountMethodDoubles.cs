using System;
using System.Collections.Generic;

class GenericCountMethodDoubles
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<double> doubleList = new List<double>();
        for (int i = 0; i < n; i++)
        {
            double number = double.Parse(Console.ReadLine());
            doubleList.Add(number);
        }
        double comparingElement = double.Parse(Console.ReadLine());
        Console.WriteLine(Compare(doubleList, comparingElement));
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