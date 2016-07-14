using System;

public class Threeuple<O1, O2, O3>
{
    public O1 Object1 { get; set; }
    public O2 Object2 { get; set; }
    public O3 Object3 { get; set; }

    public Threeuple(O1 object1, O2 object2, O3 object3)
    {
        Object1 = object1;
        Object2 = object2;
        Object3 = object3;
    }

    public override string ToString()
    {
        return $"{this.Object1} -> {this.Object2} -> {this.Object3}";
    }
}

public class Pr11Threeuple
{
    static void Main(string[] args)
    {
        string[] nameAdressTown = Console.ReadLine().Split();
        string fullName = nameAdressTown[0] + " " + nameAdressTown[1];
        string adress = nameAdressTown[2];
        string town = nameAdressTown[3];

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(fullName, adress, town);

        string[] personBeerDrunk = Console.ReadLine().Split();
        string person = personBeerDrunk[0];
        int beer = int.Parse(personBeerDrunk[1]);
        bool drunk;
        if (personBeerDrunk[2] == "drunk")
        {
            drunk = true;
        }
        else
        {
            drunk = false;
        }
        Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(person,beer,drunk);

        string[] personCashBank = Console.ReadLine().Split();
        string name = personCashBank[0];
        double cash = double.Parse(personCashBank[1]);
        string bank = personCashBank[2];
        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name,cash,bank);

        Console.WriteLine(firstThreeuple);
        Console.WriteLine(secondThreeuple);
        Console.WriteLine(thirdThreeuple);
    }
}