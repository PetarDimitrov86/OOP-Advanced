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

public class Card : IComparable<Card>
{
    private string Rank { get; }
    private string Suit { get; }

    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }
    
    //public Card(Rank rank, Suit suit)

    public int Power
    { get { return (int) Enum.Parse(typeof(Rank), this.Rank) + (int) Enum.Parse(typeof(Suit), this.Suit); } }
    // get { return (int) this.Rank + (int) this.Suit; }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }

    public override string ToString()
    {
        int suit = (int)Enum.Parse(typeof(Rank), this.Rank);
        int rank = (int)Enum.Parse(typeof(Suit), this.Suit);

        return $"Card name: {Enum.Parse(typeof(Rank), this.Rank)} of {Enum.Parse(typeof(Suit), this.Suit)}; Card power: {suit + rank}";
        // return $"Card name: {this.Rank.ToString()} of {this.Suit.ToString()}; Card power: {(int) this.Rank + (int) this.Suit}";
    }
}

class CardCompareTo
{
    static void Main(string[] args)
    {
        string rankOne = Console.ReadLine();
        string suitOne = Console.ReadLine();
        Card cardOne = new Card(rankOne, suitOne);

        string rankTwo = Console.ReadLine();
        string suitTwo = Console.ReadLine();
        Card cardTwo = new Card(rankTwo, suitTwo);

        Card strongCard = new Card(" ", " ");
        if (cardOne.CompareTo(cardTwo) == 1)
        {
            strongCard = cardOne;
        }
        else
        {
            strongCard = cardTwo;
        }
        Console.WriteLine(strongCard);
    }
}
