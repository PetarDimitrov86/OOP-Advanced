using LambdaCore_Skeleton.Models.Fragments;

namespace LambdaCore_Skeleton.Commands
{
    using System;
    using Enums;
    using Factories;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Globals;

    public class AttachFragmentCommand : Command
    {
        private FragmentFactory fragmentFactory;

        public AttachFragmentCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
            this.fragmentFactory = new FragmentFactory();
        }

        public override void Execute()
        {
            IFragment currentFragment = null;
            try
            {
                if (Input[1] == FragmentType.Cooling.ToString())
                {
                    currentFragment = fragmentFactory.CreateCoolingFragment(Input);
                }
                else if (Input[1] == FragmentType.Nuclear.ToString())
                {
                    currentFragment = fragmentFactory.CreateNuclearFragment(Input);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to attach Fragment {Input[2]}!");
                return;
            }
            if (currentFragment == null || Global.SelectedCore == null)
            {
                Console.WriteLine($"Failed to attach Fragment {Input[2]}!");
                return;
            }
            ICore coreToReplaceInTheRepository = Global.SelectedCore;
            var result = this.Repository.FirstOrDefault(x => x == coreToReplaceInTheRepository);

            if (currentFragment is NuclearFragment)
            {
                result.Durability -= currentFragment.PressureAffection;
                if (result.Durability < 0)
                {
                    result.Durability = 0;
                }
            }
            else if (currentFragment is CoolingFragment)
            {
                if (result.Durability == 0)
                {
                    result.Durability += currentFragment.PressureAffection;
                }
            }
            result.Fragments.Push(currentFragment);
     
            Console.WriteLine($"Successfully attached Fragment {currentFragment.Name} to Core {result.Name}!");
        }
    }
}
