using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
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
        if (internalIndex < collection.Count - 1)
        {
            internalIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (internalIndex == collection.Count - 1)
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

    public void PrintAll()
    {
        foreach (var element in collection)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < collection.Count; i++)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

class Collection
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split();
        List<string> inputCollection = new List<string>();
        for (int i = 1; i < elements.Length; i++)
        {
            inputCollection.Add(elements[i]);
        }
        ListyIterator<string> listy = new ListyIterator<string>();
        listy.Create(inputCollection);
        string command = Console.ReadLine();
        while (command != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(listy.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listy.HasNext());
                    break;
                case "Print":
                    try
                    {
                        listy.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "PrintAll":
                    listy.PrintAll();
                    break;
            }
            command = Console.ReadLine();
        }
    }
}