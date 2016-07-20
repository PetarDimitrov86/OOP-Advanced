public interface IMission
{
    string CodeName { get; }
    string State { get; set; }

    void CompleteMission();
}