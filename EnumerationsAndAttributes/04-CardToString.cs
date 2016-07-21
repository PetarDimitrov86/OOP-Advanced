using System;

public enum Suit
{
    Clubs,
    Diamonds = 13,
    Hearts = 26,
    Spades = 39
}

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

public class Card
{
    private string Rank { get; }
    private string Suit { get; }

    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public override string ToString()
    {
        int suit = (int)Enum.Parse(typeof(Rank), this.Rank);
        int rank = (int)Enum.Parse(typeof(Suit), this.Suit);

        return $"Card name: {Enum.Parse(typeof(Rank), this.Rank)} of {Enum.Parse(typeof(Suit), this.Suit)}; Card power: {suit + rank}";
    }
}

class CardToString
{
    static void Main(string[] args)
    {
        string rank = Console.ReadLine();
        string suit = Console.ReadLine();
        Card card = new Card(rank, suit);
        Console.WriteLine(card);
    }
}