using System;

public interface Callable
{
    string CallNumber(string number);
}

public interface Browseable
{
    string BrowseWebsite(string url);
}

public class Smartphone : Callable, Browseable
{
    private string model;

    public Smartphone(string model)
    {
        this.model = model;
    }

    public string CallNumber(string number)
    {
        bool validNumber = true;
        for (int i = 0; i < number.Length; i++)
        {
            if (!char.IsDigit(number[i]))
            {
                validNumber = false;
            }
        }
        if (!validNumber)
        {
            return "Invalid number!";
        }

        return $"Calling... {number}";
    }

    public string BrowseWebsite(string url)
    {
        bool validURL = true;
        for (int i = 0; i < url.Length; i++)
        {
            if (char.IsDigit(url[i]))
            {
                validURL = false;
            }
        }
        if (!validURL)
        {
            return "Invalid URL!";
        }

        return $"Browsing: {url}!";
    }
}

public class Telephony
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split();
        string[] urls = Console.ReadLine().Split();

        Smartphone ourSmartphone = new Smartphone("Lenovo");
        foreach (var phoneNumber in phoneNumbers)
        {
            Console.WriteLine(ourSmartphone.CallNumber(phoneNumber));
        }
        foreach (var url in urls)
        {
            Console.WriteLine(ourSmartphone.BrowseWebsite(url));
        }
    }
}