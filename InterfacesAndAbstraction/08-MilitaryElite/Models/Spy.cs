using System;
using System.Text;

public class Spy : ISpy
{
    public Spy(string id, string firstName, string lastName, string codeNumber)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.CodeNumber = codeNumber;
    }

    public string CodeNumber { get; set; }
    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.ID}");
        sb.Append(Environment.NewLine);
        sb.Append($"Code Number: {this.CodeNumber.TrimStart('0')}");
        return sb.ToString();
    }
}