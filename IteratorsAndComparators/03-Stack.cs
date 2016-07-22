using System;
using System.Collections;
using System.Collections.Generic;

public class MyCustomStack<T> : IEnumerable<T>
{
    private T[] collection;

    public MyCustomStack()
    {
        this.collection = new T[0];
    }

    public void Push(T element)
    {
        T[] tempCollection = new T[collection.Length + 1];
        collection.CopyTo(tempCollection, 0);
        tempCollection[collection.Length] = element;
        this.collection = tempCollection;
    }

    public void Pop()
    {
        if (collection.Length == 0)
        {
            Console.WriteLine("No elements");
            return;
        }
        T[] tempCollection = new T[collection.Length - 1];
        for (int i = 0; i < tempCollection.Length; i++)
        {
            tempCollection[i] = collection[i];
        }
        collection = tempCollection;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = collection.Length - 1; i >= 0 ; i--)
        {
            yield return collection[i];
        }
        for (int i = collection.Length - 1; i >= 0; i--)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class Stack
{
    static void Main(string[] args)
    {
        MyCustomStack<string> customStack = new MyCustomStack<string>();
        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] commandSplit = command.Split(new char[] {',' ,' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandSplit[0] == "Push")
            {
                for (int i = 1; i < commandSplit.Length ; i++)
                {
                    customStack.Push(commandSplit[i]);
                }
            }
            else if (commandSplit[0] == "Pop")
            {
                customStack.Pop();
            }
            command = Console.ReadLine();
        }
        foreach (var item in customStack)
        {
            Console.WriteLine(item);
        }
    }
}