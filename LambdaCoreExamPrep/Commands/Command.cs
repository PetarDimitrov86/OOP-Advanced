using System.Collections.Generic;
using LambdaCore_Skeleton.Models.Cores;

namespace LambdaCore_Skeleton.Commands
{
    using Collection;
    using Interfaces;

    public abstract class Command : ICommand
    {
        private string[] input;
        private List<ICore> repository;

        protected Command(string[] input, List<ICore> repository)
        {
            this.Input = input;
            this.Repository = repository;
        }

        public string Message { get; }

        public abstract void Execute();

        public string[] Input { get; protected set; }

        public List<ICore> Repository { get; protected set; }
    }
}