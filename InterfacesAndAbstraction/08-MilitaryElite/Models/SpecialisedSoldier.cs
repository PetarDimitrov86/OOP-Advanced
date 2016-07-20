using System;

public class SpecialisedSoldier : ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.Corps = corps;
    }

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

    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public double Salary { get; }
}