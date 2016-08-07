namespace LambdaCore_Solution.Models.Fragments
{
    using System;

    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Interfaces;

    public class BaseFragment : IFragment
    {
        private string name;

        private FragmentType type;

        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                this.name = value;
            }
        }

        public FragmentType Type
        {
            get
            {
                return this.type;
            }

            protected set
            {
                this.type = value;
            }
        }

        public virtual int PressureAffection
        {
            get
            {
                return this.pressureAffection;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value of pressure affection should not be negative!");
                }

                this.pressureAffection = value;
            }
        }
    }
}
