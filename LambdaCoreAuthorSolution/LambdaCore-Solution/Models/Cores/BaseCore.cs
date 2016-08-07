namespace LambdaCore_Solution.Models.Cores
{
    using System;
    using System.Text;

    using LambdaCore_Solution.Collection;
    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Interfaces;

    public abstract class BaseCore : ICore
    {
        private string name;

        private int durability;

        private LStack<IFragment> attachedFragments;

        protected BaseCore(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
            this.attachedFragments = new LStack<IFragment>();
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

        public virtual int Durability
        {
            get
            {
                // THE CORE'S DURABILITY - THE CURRENT PRESSURE ON THE CORE
                // IF THE PRESSURE IS BELOW ZERO OR ZERO THE CORE'S DURABILITY WILL REMAIN AT MAXIMUM
                // BECAUSE THE .getCurrentPressure() METHOD WILL NOT RETURN A VALUE BELOW ZERO
                int result = (int)((long)this.durability - this.CurrentPressure);

                // THE DURABILITY SHOULD NOT FALL BELOW ZERO
                return result > 0 ? result : 0;
            }

            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.durability = value;
            }
        }

        public int FragmentsCount
        {
            get
            {
                return this.attachedFragments.Count();
            }
        }

        public long CurrentPressure
        {
            get
            {
                long totalPressure = 0;

                foreach (IFragment fragment in this.attachedFragments)
                {
                    if (fragment.Type.Equals(FragmentType.Nuclear))
                    {
                        totalPressure += fragment.PressureAffection;
                    }
                    else
                    {
                        totalPressure -= fragment.PressureAffection;
                    }
                }

                // IF THE PRESSURE IS BELOW ZERO IT DOES NOT PRESENT ANY CHANGE TO THE CORE'S DURABILITY
                // THAT IS WHY, WE JUST RETURN ZERO
                return totalPressure > 0 ? totalPressure : 0;
            }
        }

        protected CoreStatus Status
        {
            get
            {
                return this.CurrentPressure > 0 ? CoreStatus.CRITICAL : CoreStatus.NORMAL;
            }
        }

        public IFragment AttachFragment(IFragment fragment)
        {
            IFragment result = this.attachedFragments.Push(fragment);
            return result;
        }

        public IFragment DetachFragment()
        {
            IFragment result = this.attachedFragments.Pop();
            return result;
        }

        public IFragment PeekFragment()
        {
            IFragment result = this.attachedFragments.Peek();
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Core {0}:", this.Name) + Environment.NewLine);
            result.Append(string.Format("####Durability: {0}", this.Durability) + Environment.NewLine);
            result.Append(string.Format("####Status: {0}", this.Status));

            return result.ToString();
        }
    }
}
