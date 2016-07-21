using System;

public enum Suits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public class CardSuit
{
    static void Main()
    {
        string enumToDisplay = Console.ReadLine();
        var cardTypes = Enum.GetValues(typeof(Suits));
        Console.WriteLine(enumToDisplay + ":");
        foreach (var cardType in cardTypes)
        {
            Console.WriteLine($"Ordinal value: {(int)cardType}; Name value: {cardType}");
        }
    }
}