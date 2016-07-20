public abstract class Soldier : ISoldier
{
    private string id;
    private string firstName;
    private string lastName;

    public Soldier(string id, string firstName, string lastName)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string ID { get; }
    public string FirstName { get; }
    public string LastName { get; }
}