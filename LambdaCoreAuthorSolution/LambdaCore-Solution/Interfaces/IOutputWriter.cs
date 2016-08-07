namespace LambdaCore_Solution.Interfaces
{
    public interface IOutputWriter
    {
        void Write(string output);
             
        void Write(string format, string output);
             
        void WriteLine(string output);
             
        void WriteLine(string format, string output);
    }
}
