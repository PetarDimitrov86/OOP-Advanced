using System;
using System.Collections.Generic;
using System.Linq;

public class Card : IComparable<Card>
{
    public Card(Rank rank, Suit suit, string owner)
    {
        this.Rank = rank;
        this.Suit = suit;
        this.Owner = owner;
    }

    public Rank Rank { get; }
    
    public Suit Suit { get; }

    public int Power { get { return (int) this.Rank + (int) this.Suit; } }

    public string Owner { get; }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }

    public override int GetHashCode()
    {
        return this.Power + (int) this.Rank + (int) this.Suit;
    }

    public override bool Equals(object obj)
    {
        var newObject = obj as Card;

        return this.GetHashCode() == newObject.GetHashCode();
    }
}

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


public class CardGame
{
    static void Main()
    {
        HashSet<Card> cardsGivenAway = new HashSet<Card>();

        string playerOne = Console.ReadLine();
        string playerTwo = Console.ReadLine();

        while (cardsGivenAway.Count < 10)
        {
            string[] cardsInfo = Console.ReadLine().Split();
            string rankString = cardsInfo[0];
            string suitString = cardsInfo[2];
            Rank rank = Rank.Ace;
            Suit suit = Suit.Clubs;

            if (Enum.TryParse(rankString, out rank) && Enum.TryParse(suitString, out suit))
            {
                Card card = new Card(rank, suit, playerOne);
                if (cardsGivenAway.Count >= 5)
                {
                    card = new Card(rank, suit, playerTwo);
                }
                if (cardsGivenAway.Contains(card))
                {
                    Console.WriteLine("Card is not in the deck.");
                    continue;
                }
                cardsGivenAway.Add(card);
            }
            else
            {
                Console.WriteLine("No such card exists.");
            }
        }
        
        Card biggestCard = cardsGivenAway.Max();
        Console.WriteLine($"{biggestCard.Owner} wins with {biggestCard.Rank} of {biggestCard.Suit}.");
    }
}