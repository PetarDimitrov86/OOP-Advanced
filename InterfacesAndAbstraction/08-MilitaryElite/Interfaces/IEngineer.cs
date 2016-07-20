using System.Collections.Generic;

public interface IEngineer : ISpecialisedSoldier
{
    List<Repair> Repairs { get; }
}