namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            IUnit unit = UnitFactory.CreateUnit(Data[1]);
            Repository.AddUnit(unit);
            return $"{this.Data[1]} added!";
        }
    }
}
