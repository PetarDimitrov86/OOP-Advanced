using System;
using System.Collections.Generic;
using System.Linq;

public class GenericBox<T>
{
    private T type;

    public GenericBox(T type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        return $"{this.type.GetType().FullName}: {this.type}";
    }

    public static void Swap<T>(List<GenericBox<T>> list, int firstPosition, int secondPosition)
    {
        GenericBox<T> oldFirstPositionValue = list[firstPosition];
        list[firstPosition] = list[secondPosition];
        list[secondPosition] = oldFirstPositionValue;
    }
}

class GenericSwapMethodStrings
{ 
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<GenericBox<string>> genericList = new List<GenericBox<string>>();
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            GenericBox<string> genericString = new GenericBox<string>(input);
            genericList.Add(genericString);
        }
        int[] swapPositionsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int startIndex = swapPositionsInfo[0];
        int lastIndex = swapPositionsInfo[1];
        GenericBox<string>.Swap(genericList, startIndex, lastIndex);
        foreach (var generic in genericList)
        {
            Console.WriteLine(generic);
        }
    }
}