using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Globals;
    using Models.Cores;

    public class RemoveCoreCommand : Command
    {
        public RemoveCoreCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
        }

        public override void Execute()
        {
            var coreToRemove = this.Repository.FirstOrDefault(x => x.Name == Input[1]);
            if (coreToRemove == null)
            {
                Console.WriteLine($"Failed to remove Core {Input[1]}!");
                return;
            }
            if (coreToRemove == Global.SelectedCore)
            {
                Global.SelectedCore = null;
            }

            this.Repository.Remove(coreToRemove);
            Global.CurrentCoreLetter--;
            Console.WriteLine(SuccessMessages.SuccessfullyRemoveCore, Input[1]);
        }
    }
}