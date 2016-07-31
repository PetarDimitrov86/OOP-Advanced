namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using Attributes;

    class Engine : IRunnable
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory factory;
        private ICommandInterpreter interpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory, ICommandInterpreter interpreter)
        {
            this.repository = repository;
            this.factory = unitFactory;
            this.interpreter = interpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = interpreter.InterpretCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
