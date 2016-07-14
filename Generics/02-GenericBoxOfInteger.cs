using System;

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
}

public class GenericBoxOfInteger
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            GenericBox<int> genericInt = new GenericBox<int>(number);
            Console.WriteLine(genericInt);
        }
    }
}