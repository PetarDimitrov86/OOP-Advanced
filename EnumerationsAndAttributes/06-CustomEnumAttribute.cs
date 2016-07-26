using System;

[Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
public enum Suit
{
    Clubs,
    Diamonds = 13,
    Hearts = 26,
    Spades = 39
}

[Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
public enum Rank
{
    Ace = 14,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    public string Type { get; }

    public string Category { get; }

    public string Description { get; }

    public TypeAttribute(string type, string category, string description)
    {
        Type = type;
        Category = category;
        Description = description;
    }
}

public class CustomEnumAttribute
{
    static void Main()
    {
        string input = Console.ReadLine();
        Type typeRank = typeof(Rank);
        Type typeSuit = typeof(Suit);
        object[] rankAttributes = typeRank.GetCustomAttributes(false);
        object[] suitAttributes = typeSuit.GetCustomAttributes(false);
        switch (input)
        {
            case "Rank":
                foreach (TypeAttribute attr in rankAttributes)
                {
                    Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
                }
                break;
            case "Suit":
                foreach (TypeAttribute attr in suitAttributes)
                {
                    Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
                }
                break;
        }
    }
}