namespace LambdaCore_Skeleton.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Globals;
    using Interfaces;

    public class DetachFragmentCommand : Command
    {
        public DetachFragmentCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
        }

        public override void Execute()
        {
            ICore currentlySelectedCore = this.Repository.FirstOrDefault(x => x == Global.SelectedCore);

            if (currentlySelectedCore == null || currentlySelectedCore.Fragments.IsEmpty())
            {
                Console.WriteLine("Failed to detach Fragment!");
                return;
            }

            currentlySelectedCore.Durability -= currentlySelectedCore.Fragments.Peek().PressureAffection;
            currentlySelectedCore.Fragments.Pop();
        }
    }
}
