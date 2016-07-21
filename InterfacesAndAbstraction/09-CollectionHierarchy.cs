using System;
using System.Collections.Generic;

public interface IAddable
{
    int Add(string element);
}

public interface IRemoveable : IAddable
{
    string Remove();
}

public interface IMyListable : IRemoveable
{
    int Used { get; }
}

public class AddCollection : IAddable
{
    List<string> addCollectionList;

    public AddCollection()
    {
        this.addCollectionList = new List<string>();
    }

    public int Add(string element)
    {
        this.addCollectionList.Add(element);
        return addCollectionList.Count - 1;
    }
}

public class AddRemoveCollection : IRemoveable
{
    private List<string> addRemoveCollection;

    public AddRemoveCollection()
    {
        this.addRemoveCollection = new List<string>();
    }

    public int Add(string element)
    {
        this.addRemoveCollection.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string elementToRemove = this.addRemoveCollection[addRemoveCollection.Count - 1];
        this.addRemoveCollection.RemoveAt(addRemoveCollection.Count - 1);
        return elementToRemove;
    }
}

public class MyList : IMyListable
{
    private List<string> myList;

    public MyList()
    {
        this.myList = new List<string>();
    }

    public int Used { get { return this.myList.Count; } }

    public int Add(string element)
    {
        this.myList.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string elementToRemove = this.myList[0];
        this.myList.RemoveAt(0);
        return elementToRemove;
    }
}

public class CollectionHierarchy
{
    static void Main()
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        string[] elementsToAdd = Console.ReadLine().Split();
        int removeOperations = int.Parse(Console.ReadLine());

        foreach (var element in elementsToAdd)
        {
            Console.Write(addCollection.Add(element) + " ");
        }
        Console.WriteLine();

        foreach (var element in elementsToAdd)
        {
            Console.Write(addRemoveCollection.Add(element) + " ");
        }
        Console.WriteLine();

        foreach (var element in elementsToAdd)
        {
            Console.Write(myList.Add(element) + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < removeOperations; i++)
        {
            Console.Write(addRemoveCollection.Remove() + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < removeOperations; i++)
        {
            Console.Write(myList.Remove() + " ");
        }
        Console.WriteLine();
    }
}