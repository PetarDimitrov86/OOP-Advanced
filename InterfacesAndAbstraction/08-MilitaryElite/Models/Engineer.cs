using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : IEngineer
{
    private List<Repair> repairs;
    private string corps;
    public Engineer(string id, string firstName, string lastName, double salary, string corps)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.Corps = corps;
        this.Repairs = new List<Repair>();
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

    public List<Repair> Repairs
    {
        get { return this.repairs; }
        set { this.repairs = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
        sb.Append(Environment.NewLine);
        sb.Append($"Corps: {this.Corps}");
        sb.Append(Environment.NewLine);
        sb.Append($"Repairs:");
        for (int i = 0; i < repairs.Count; i++)
        {
            sb.Append(Environment.NewLine);
            sb.Append(repairs[i]);
        }
        return sb.ToString();
    }
}