using System;

public class Mission : IMission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public string CodeName
    {
        get
        {
            return codeName;
        }

        set
        {
            codeName = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }

        set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException("Invalid Input");
            }
            state = value;
        }
    }

    public override string ToString()
    {
        return $"  Code Name: {this.CodeName} State: {this.State}";
    }
}