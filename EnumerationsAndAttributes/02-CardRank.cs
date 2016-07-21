using System;
public enum Ranks
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
}

public class CardRank
{
    static void Main(string[] args)
    {
        string enumToDisplay = Console.ReadLine();
        var cardTypes = Enum.GetValues(typeof(Ranks));
        Console.WriteLine(enumToDisplay + ":");
        foreach (var cardType in cardTypes)
        {
            Console.WriteLine($"Ordinal value: {(int)cardType}; Name value: {cardType}");
        }
    }
}