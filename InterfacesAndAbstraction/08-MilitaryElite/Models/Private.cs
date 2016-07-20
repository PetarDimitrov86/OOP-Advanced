using System.Text;

public class Private : IPrivate
{
    private double salary;

    public Private(string id, string firstName, string lastName, double salary)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
    }

    public double Salary
    {
        get
        {
            return salary;
        }

        set
        {
            salary = value;
        }
    }
    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}";
    }
}