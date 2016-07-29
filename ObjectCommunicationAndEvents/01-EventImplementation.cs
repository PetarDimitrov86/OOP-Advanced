using System;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

public class Dispatcher
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { OnNameChange(new NameChangeEventArgs(value));}
    }
    public event NameChangeEventHandler NameChange;

    public void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange?.Invoke(this, args);
    }
}

public class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}

public class NameChangeEventArgs : EventArgs
{
    public NameChangeEventArgs(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

public class EventImplementation
{
    static void Main()
    {
        Handler handler = new Handler();
        Dispatcher dispatcher = new Dispatcher();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string input = Console.ReadLine();
        while (input!= "End")
        {
            dispatcher.Name = input;
            input = Console.ReadLine();
        }
    }
}