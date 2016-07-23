using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stone
{
    private int number;

    public Stone(int number)
    {
        this.Number = number;
    }

    public int Number { get; }

    public override string ToString()
    {
        return this.Number.ToString();
    }
}

public class Lake : IEnumerable<Stone>
{
    public List<Stone> Stones { get; }

    public Lake()
    {
        Stones = new List<Stone>();
    }
    
    public IEnumerator<Stone> GetEnumerator()
    {
        for (int i = 0; i < Stones.Count; i+=2)
        {
            yield return Stones[i];
        }
        int lastEvenPosition = Stones.Count - 1;
        if (Stones.Count % 2 == 1)
        {
            lastEvenPosition--;
        }
        for (int i = lastEvenPosition; i >= 0; i-=2)
        {
            yield return Stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class Froggy
{
    static void Main()
    {
        Lake lake = new Lake();
        int[] numbers = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        foreach (var number in numbers)
        {
            Stone stone = new Stone(number);
            lake.Stones.Add(stone);
        }
        Console.WriteLine(string.Join(", ", lake));
    }
}