using System;
using System.Collections.Generic;
using System.Text;

public class Commando : ICommando
{
    private List<Mission> missions;
    private string corps;

    public Commando(string id, string firstName, string lastName, double salary, string corps)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.Corps = corps;
        this.Missions = new List<Mission>();
    }

    public List<Mission> Missions
    {
        get
        {
            return missions;
        }

        set
        {
            missions = value;
        }
    }
    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public double Salary { get; }

    public string Corps
    {
        get
        {
            return corps;
        }
        set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException("Invalid Input");
            }
            corps = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
        sb.Append(Environment.NewLine);
        sb.Append($"Corps: {this.Corps}");
        sb.Append(Environment.NewLine);
        sb.Append($"Missions:");
        for (int i = 0; i < missions.Count; i++)
        {
            sb.Append(Environment.NewLine);
            sb.Append(missions[i]);
        }
        return sb.ToString();
    }
}