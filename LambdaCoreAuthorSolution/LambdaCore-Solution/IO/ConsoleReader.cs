namespace LambdaCore_Solution.IO
{
    using System;

    using LambdaCore_Solution.Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
