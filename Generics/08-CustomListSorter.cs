using System;

public class GenericList<T> where T : IComparable<T>
{
    private T[] collection;

    public GenericList()
    {
        this.collection = new T[0];
    }

    public int Count()
    {
        return this.collection.Length;
    }

    public T this[int index]
    {
        get { return this.collection[index]; }
    }

    public void Add(T element)
    {
        T[] biggerCollection = new T[collection.Length + 1];
        for (int i = 0; i < collection.Length; i++)
        {
            biggerCollection[i] = collection[i];
        }
        biggerCollection[biggerCollection.Length - 1] = element;
        collection = biggerCollection;
    }

    public void Remove(int index)
    {
        if (index < this.collection.Length)
        {
            T[] smallerCollection = new T[collection.Length - 1];
            for (int i = 0; i < index; i++)
            {
                smallerCollection[i] = collection[i];
            }
            for (int i = index + 1; i < collection.Length; i++)
            {
                smallerCollection[i - 1] = collection[i];
            }
            collection = smallerCollection;
        }
    }

    public bool Contains(T element)
    {
        foreach (var item in collection)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int indexFirst, int indexSecond)
    {
        T firstElement = collection[indexFirst];
        collection[indexFirst] = collection[indexSecond];
        collection[indexSecond] = firstElement;
    }

    public int Compare(T element)
    {
        int counter = 0;
        for (int i = 0; i < collection.Length; i++)
        {
            if (collection[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }

    public T Max()
    {
        T maxElement = collection[0];
        foreach (var item in collection)
        {
            if (item.CompareTo(maxElement) > 0)
            {
                maxElement = item;
            }
        }
        return maxElement;
    }

    public T Min()
    {
        T minElement = collection[0];
        foreach (var item in collection)
        {
            if (item.CompareTo(minElement) < 0)
            {
                minElement = item;
            }
        }
        return minElement;
    }

    public void Print()
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}

public class Sorter
{
    public static GenericList<T> Sort<T> (GenericList<T> ourList) where T : IComparable<T>
    {
        bool isSorted = false;
        while (!isSorted)
        {
            bool elementFound = false;
            for (int i = 0; i < ourList.Count() - 1; i++)
            {
                if (ourList[i].CompareTo(ourList[i+1]) > 0)
                {
                    ourList.Swap(i, i+1);
                    elementFound = true;
                    break;
                }
            }
            if (elementFound == false)
            {
                isSorted = true;
            }
        }
        return ourList;
    }
}

public class CustomListSorter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        GenericList<string> ourList = new GenericList<string>();
        while (input != "END")
        {
            string[] commandInfo = input.Split();
            switch (input)
            {
                case "Min":
                    Console.WriteLine(ourList.Min());
                    break;
                case "Max":
                    Console.WriteLine(ourList.Max());
                    break;
                case "Print":
                    ourList.Print();
                    break;
                case "Sort":
                    ourList = Sorter.Sort(ourList);
                    break;
            }
            if (input.Contains("Add"))
            {
                string textToAdd = commandInfo[1];
                ourList.Add(textToAdd);
            }
            else if (input.Contains("Remove"))
            {
                int indexToRemove = int.Parse(commandInfo[1]);
                ourList.Remove(indexToRemove);

            }
            else if (input.Contains("Contains"))
            {
                Console.WriteLine(ourList.Contains(commandInfo[1]));
            }
            else if (input.Contains("Swap"))
            {
                int firstIndex = int.Parse(commandInfo[1]);
                int secondIndex = int.Parse(commandInfo[2]);
                ourList.Swap(firstIndex, secondIndex);
            }
            else if (input.Contains("Greater"))
            {
                Console.WriteLine(ourList.Compare(commandInfo[1]));
            }
            input = Console.ReadLine();
        }
    }
}