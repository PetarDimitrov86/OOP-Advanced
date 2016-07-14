using System;
using System.Collections.Generic;

public static class GenericList<T>
{
    public static List<T> list = new List<T>();

    public static void Add(T element)
    {
        list.Add(element);
    }

    public static void Remove(int index)
    {
        list.RemoveAt(index);
    }

    public static bool Contains(T element)
    {
        if (list.Contains(element))
        {
            return true;
        }
        return false;
    }

    public static void Swap(int indexFirst, int indexSecond)
    {
        T firstElement = list[indexFirst];
        list[indexFirst] = list[indexSecond];
        list[indexSecond] = firstElement;
    }

    public static int CountGreaterThan<T>(List<T> list, T element)
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

    public static T Max<T>(List<T> list)
      where T : IComparable<T>
    {
        T maxElement = list[0];
        foreach (var generic in list)
        {
            if (generic.CompareTo(maxElement) > 0)
            {
                maxElement = generic;
            }
        }
        return maxElement;
    }

    public static T Min<T>(List<T> list)
      where T : IComparable<T>
    {
        T minElement = list[0];
        foreach (var generic in list)
        {
            if (generic.CompareTo(minElement) < 0)
            {
                minElement = generic;
            }
        }
        return minElement;
    }
}

class CustomList
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input!= "END")
        {
            string[] commandInfo = input.Split();
            switch (input)
            {
                case "Min":
                    Console.WriteLine(GenericList<string>.Min(GenericList<string>.list));
                    break;
                case "Max":
                    Console.WriteLine(GenericList<string>.Max(GenericList<string>.list));
                    break;
                case "Print":
                    Console.WriteLine(string.Join(Environment.NewLine, GenericList<string>.list));
                    break;
            }
            if (input.Contains("Add"))
            {
                GenericList<string>.Add(commandInfo[1]);
            }
            else if (input.Contains("Remove"))
            {
                GenericList<string>.Remove(int.Parse(commandInfo[1]));
            }
            else if (input.Contains("Contains"))
            {
                Console.WriteLine(GenericList<string>.Contains(commandInfo[1]).ToString());
            }
            else if (input.Contains("Swap"))
            {
                GenericList<string>.Swap(int.Parse(commandInfo[1]), int.Parse(commandInfo[2]));
            }
            else if (input.Contains("Greater"))
            {
                Console.WriteLine(GenericList<string>.CountGreaterThan(GenericList<string>.list, commandInfo[1]));
            }
            input = Console.ReadLine();
        }
    }
}