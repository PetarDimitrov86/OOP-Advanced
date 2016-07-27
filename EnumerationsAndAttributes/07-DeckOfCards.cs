using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

class DeckOfCards
{
    static void Main(string[] args)
    {
        var suitArray = typeof(Suit).GetEnumValues();
        var rankArray = typeof(Rank).GetEnumValues();

        foreach (var suit in suitArray)
        {
            foreach (var rank in rankArray)
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}