namespace LambdaCore_Solution.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LambdaCore_Solution.Exceptions;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class NuclearPowerPlant : IPowerPlant
    {
        private ICore currentlySelectedCore;

        private IDictionary<string, ICore> powerPlantCores;

        private string currentCoreName;

        public NuclearPowerPlant()
        {
            this.powerPlantCores = new Dictionary<string, ICore>();
            this.CurrentlySelectedCore = null;
        }

        public int CountOfCores
        {
            get
            {
                return this.powerPlantCores.Count;
            }
        }

        public int CountOfFragments
        {
            get
            {
                int countOfFragments = 0;

                foreach (var core in this.powerPlantCores)
                {
                    countOfFragments += core.Value.FragmentsCount;
                }

                return countOfFragments;
            }
        }

        public string NextCoreName
        {
            get
            {
                string result = this.CurrentCoreName;
                this.UpdateCurrentCoreName();

                return result;
            }
        }

        public ICore CurrentlySelectedCore
        {
            get
            {
                return this.currentlySelectedCore;
            }

            private set
            {
                this.currentlySelectedCore = value;
            }
        }

        protected string CurrentCoreName
        {
            get
            {
                if (this.currentCoreName == null)
                {
                    return "A";
                }

                return this.currentCoreName;
            }

            private set
            {
                this.currentCoreName = value;
            }
        }

        protected long TotalSystemDurability
        {
            get
            {
                long totalSystemDurability = 0L;

                foreach (var coreEntry in this.powerPlantCores)
                {
                    totalSystemDurability += coreEntry.Value.Durability;
                }

                return totalSystemDurability;
            }
        }

        public bool HasSelectedCore()
        {
            return this.CurrentlySelectedCore != null;
        }

        public void SelectCore(string coreName)
        {
            this.CurrentlySelectedCore = this.GetCore(coreName);
        }

        public void AttachCore(ICore core)
        {
            this.powerPlantCores.Add(core.Name, core);
        }

        public ICore DetachCore(string coreName)
        {
            if (!this.ContainsCore(coreName))
            {
                throw new UnexistentCoreException(string.Format(Messages.FailureCoreRemoveMessage, coreName));
            }

            ICore result = this.powerPlantCores[coreName];
            this.powerPlantCores.Remove(coreName);

            if (this.CurrentlySelectedCore.Equals(result))
            {
                this.CurrentlySelectedCore = null;
            }

            return result;
        }

        public ICore GetCore(string coreName)
        {
            if (!this.ContainsCore(coreName))
            {
                throw new UnexistentCoreException(string.Format(Messages.FailureCoreRetrieveMessage, coreName));
            }

            ICore result = this.powerPlantCores[coreName];
            return result;
        }

        public bool ContainsCore(string coreName)
        {
            bool result = this.powerPlantCores.ContainsKey(coreName);
            return result;
        }

        public void AttachFragment(IFragment fragment)
        {
            if (!this.HasSelectedCore())
            {
                throw new NoSelectedCoreException();
            }

            this.CurrentlySelectedCore.AttachFragment(fragment);
        }

        public IFragment DetachFragment()
        {
            if (!this.HasSelectedCore())
            {
                throw new NoSelectedCoreException();
            }

            return this.CurrentlySelectedCore.DetachFragment();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Lambda Core Power Plant Status:" + Environment.NewLine);
            result.Append(string.Format("Total Durability: {0}", this.TotalSystemDurability) + Environment.NewLine);
            result.Append(string.Format("Total Cores: {0}", this.CountOfCores) + Environment.NewLine);
            result.Append(string.Format("Total Fragments: {0}", this.CountOfFragments) + Environment.NewLine);

            foreach (var coreEntry in this.powerPlantCores)
            {
                result.Append(coreEntry.Value + Environment.NewLine);
            }

            return result.ToString().Trim();
        }

        private void UpdateCurrentCoreName()
        {
            char oldValue = this.CurrentCoreName[0];
            this.CurrentCoreName = (char)(oldValue + Constants.CoreNextNameUpdateValue) + string.Empty;
        }
    }
}