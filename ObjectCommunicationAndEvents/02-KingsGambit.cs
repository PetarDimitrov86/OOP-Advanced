using System;
using System.Collections.Generic;
using System.Linq;

public interface IMoodChangeable
{
    string Name { get; set; }

    void OnKingAttack(object sender, EventArgs args);
}

public abstract class Person
{
    public string Name { get; set; }

    protected Person(string name)
    {
        Name = name;
    }
}

public delegate void KingAttackHandler(object sender, EventArgs e);

public class King : Person
{
    public event KingAttackHandler Attacked;

    public King(string name) : base(name)
    {
    }

    public void OnAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        OnKingAttacked(new EventArgs());
    }

    protected void OnKingAttacked(EventArgs args)
    {
        if (Attacked != null)
        {
            Attacked(this, args);
        }
    }
}

public class Footman : Person, IMoodChangeable
{
    public Footman(string name) : base(name)
    {
    }

    public void OnKingAttack(object sender, EventArgs args)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

public class RoyalGuard : Person, IMoodChangeable
{
    public RoyalGuard(string name) : base(name)
    {
    }

    public void OnKingAttack(object sender, EventArgs args)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}

public class KingsGambit
{
    static void Main()
    {
        List<IMoodChangeable> soldiersList = new List<IMoodChangeable>();

        King king = new King(Console.ReadLine());

        string[] royalGuards = Console.ReadLine().Split();
        for (int i = 0; i < royalGuards.Length; i++)
        {
            var guard = new RoyalGuard(royalGuards[i]);
            king.Attacked += guard.OnKingAttack;
            soldiersList.Add(guard);
        }

        string[] footmen = Console.ReadLine().Split();
        for (int i = 0; i < footmen.Length; i++)
        {
            var footman = new Footman(footmen[i]);
            king.Attacked += footman.OnKingAttack;
            soldiersList.Add(footman);
        }

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] commandArgs = command.Split();
            switch (commandArgs[0])
            {
                case "Attack":
                    king.OnAttack();
                    break;
                case "Kill":
                    IMoodChangeable currentSoldier = soldiersList.FirstOrDefault(s => s.Name == commandArgs[1]);
                    king.Attacked -= currentSoldier.OnKingAttack;
                    soldiersList.Remove(currentSoldier);
                    break;
            }
            command = Console.ReadLine();
        }
    }
}
