using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class MilitaryElite
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<ISoldier> soldiers = new List<ISoldier>();
        while (input!= "End")
        {
            string[] soldierInfo = input.Split();
            string soldierType = soldierInfo[0];
            string id = soldierInfo[1];
            string firstName = soldierInfo[2];
            string lastName = soldierInfo[3];
            switch (soldierType)
            {
                case "Private":
                    double salaryPri = double.Parse(soldierInfo[4]);
                    Private soldier = new Private(id, firstName, lastName, salaryPri);
                    soldiers.Add(soldier);
                    break;
                case "LeutenantGeneral":
                    double salaryGen = double.Parse(soldierInfo[4]);
                    LeutenantGeneral soldierGeneral = new LeutenantGeneral(id, firstName,lastName,salaryGen);
                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        ISoldier generalPrivate = soldiers.First(x => x.ID == soldierInfo[i]);
                        soldierGeneral.Privates.Add(generalPrivate);
                    }
                    soldiers.Add(soldierGeneral);
                    break;
                case "Engineer":
                    double salaryEngi = double.Parse(soldierInfo[4]);
                    string corps = soldierInfo[5];
                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salaryEngi, corps);
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            Repair repair = new Repair(soldierInfo[i], int.Parse(soldierInfo[i + 1]));
                            engineer.Repairs.Add(repair);
                        }
                        soldiers.Add(engineer);
                    }
                    catch (Exception)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    break;
                case "Commando":
                    double salaryCommando = double.Parse(soldierInfo[4]);
                    string corpsComando = soldierInfo[5];
                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salaryCommando, corpsComando);
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            try
                            {
                                Mission mission = new Mission(soldierInfo[i], soldierInfo[i + 1]);
                                commando.Missions.Add(mission);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                        input = Console.ReadLine();
                        continue;                       
                    }
                    break;
                case "Spy":
                    string codeNumber = soldierInfo[4];
                    Spy spy = new Spy(id, firstName,lastName, codeNumber);
                    soldiers.Add(spy);
                    break;
            }
            input = Console.ReadLine();
        }
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}