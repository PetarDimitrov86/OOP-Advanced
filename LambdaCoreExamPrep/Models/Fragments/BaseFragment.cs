using System;

namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;
    using Interfaces;

    public abstract class BaseFragment : IFragment
    {
        private string name;
        private FragmentType type;
        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
        }

        public string Name { get; protected set; }

        public FragmentType Type { get; protected set; }

        public int PressureAffection { get; set; }
    }
}
