using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private List<T> collection;
    private static int internalIndex;

    public ListyIterator()
    {
        collection = new List<T>();
        internalIndex = 0;
    }

    public void Create(List<T> elements)
    {
        this.collection = new List<T>();
        this.collection.AddRange(elements);
        internalIndex = 0;
    }

    public bool Move()
    {
        if (internalIndex < collection.Count -1)
        {
            internalIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (internalIndex == collection.Count -1)
        {
            return false;
        }
        return true;
    }

    public void Print()
    {
        try
        {
            Console.WriteLine(collection[internalIndex]);
        }
        catch (ArgumentException)
        {          
            throw new ArgumentException("Invalid Operation!");
        }
    }
}

class Pr1ListyIterator
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        ListyIterator<string> collection = new ListyIterator<string>();
        while (input!= "END")
        {
            string[] command = input.Split();
            string commandType = command[0];
            switch (commandType)
            {
                case "Create" :
                    List<string> givenCollection = new List<string>();
                    for (int i = 1; i < command.Length; i++)
                    {
                        givenCollection.Add(command[i]);
                    }
                    collection.Create(givenCollection);
                    break;
                case "Move":
                    Console.WriteLine(collection.Move());              
                    break;
                case "HasNext":
                    Console.WriteLine(collection.HasNext());
                    break;
                case "Print":
                    try
                    {
                        collection.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
            input = Console.ReadLine();
        }
    }
}