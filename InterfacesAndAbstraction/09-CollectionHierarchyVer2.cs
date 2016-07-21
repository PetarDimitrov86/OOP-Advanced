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

        PrintAdd(elementsToAdd, addCollection);
        PrintAdd(elementsToAdd, addRemoveCollection);
        PrintAdd(elementsToAdd, myList);

        PrintRemove(removeOperations, addRemoveCollection);
        PrintRemove(removeOperations, myList);
    }

    public static void PrintAdd(string[] elements, IAddable collection)
    {
        foreach (var element in elements)
        {
            Console.Write(collection.Add(element) + " ");
        }
        Console.WriteLine();
    }
    public static void PrintRemove(int removeOperations, IRemoveable collection)
    {
        for (int i = 0; i < removeOperations; i++)
        {
            Console.Write(collection.Remove() + " ");
        }
        Console.WriteLine();
    }
}