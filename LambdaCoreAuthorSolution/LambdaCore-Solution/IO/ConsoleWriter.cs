namespace LambdaCore_Solution.IO
{
    using System;

    using LambdaCore_Solution.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.Write(output);
        }

        public void Write(string format, string output)
        {
            Console.Write(string.Format(format, output));
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void WriteLine(string format, string output)
        {
            Console.WriteLine(string.Format(format, output));
        }
    }
}
