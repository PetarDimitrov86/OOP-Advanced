using System;
using System.Linq;

public class Database
{
    private int[] integers;

    public Database(params int[] integersOut)
    {
        this.integers = new int[16];
        this.Size = 0;
        if (integersOut.Length > 16)
        {
            throw new InvalidOperationException("Maximum capacity is 16!");
        }
        for (int i = 0; i < integersOut.Length; i++)
        {
            integers[i] = integersOut[i];
            Size++;
        }
    }

    public int Size { get; private set; }

    public void Add(int numberToAdd)
    {
        if (Size == 16)
        {
            throw new InvalidOperationException("Cannot add more than 16 elements in the collection");
        }
        this.integers[Size] = numberToAdd;
        Size++;
    }

    public void Remove()
    {
        if (Size == 0)
        {
            throw new InvalidOperationException("Cannto remove elements from an empty collection");
        }
        Size--;
        this.integers[Size] = 0;
    }

    public string Fetch()
    {
        return string.Join(", ", this.integers.Where(x=>x != 0));
    }

    public int this[int index] { get { return this.integers[index]; } }
}

public class DB
{
    static void Main(string[] args)
    {
    }
}