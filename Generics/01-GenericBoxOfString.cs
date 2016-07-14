using System;

public class GenericBox<T>
{
    private string name;

    public GenericBox(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"{this.name.GetType().FullName}: {this.name}";
    }
}

public class GenericBoxOfString
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            GenericBox<string> generic = new GenericBox<string>(input);
            Console.WriteLine(generic);
        }
    }
}