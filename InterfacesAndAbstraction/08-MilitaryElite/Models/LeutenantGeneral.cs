using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeutenantGeneral : ILeutenantGeneral
{
    private List<ISoldier> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.Privates = new List<ISoldier>();
    }


    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public double Salary { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
        sb.Append(Environment.NewLine);
        sb.Append("Privates:");
        for (int i = 0; i < privates.Count; i++)
        {
            sb.Append(Environment.NewLine);
            sb.Append("  " + privates[i]);
        }
        return sb.ToString();
    }

    public List<ISoldier> Privates
    {
        get { return this.privates; }
        set { this.privates = value; }
    }
}