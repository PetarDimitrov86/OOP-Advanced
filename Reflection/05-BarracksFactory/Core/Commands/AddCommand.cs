namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using Attributes;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory factory;

        public AddCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            IUnit unit = factory.CreateUnit(Data[1]);
            repository.AddUnit(unit);
            return $"{this.Data[1]} added!";
        }
    }
}
