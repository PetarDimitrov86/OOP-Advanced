using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Globals;
    using Models.Cores;

    public class SelectCoreCommand : Command
    {
        public SelectCoreCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
        }

        public override void Execute()
        {
            ICore desiredCore = this.Repository.FirstOrDefault(x => x.Name == Input[1]);
            if (desiredCore == null)
            {
                Console.WriteLine($"Failed to select Core {Input[1]}!");
                return;
            }

            Global.SelectedCore = desiredCore;
            Console.WriteLine($"Currently selected Core {desiredCore.Name}!");
        }
    }
}