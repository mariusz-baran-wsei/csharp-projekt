using System.Collections.Generic;

namespace Projekt3
{
    interface IEntity
    {
        double Health { get; set; }
        string Name { get; set; }
        IEntityAttackStrategy AttackStrategy { get; set; }
        IEntityDefendStrategy DefendStrategy { get; set; }
        Dictionary<string, List<IEntityAttackStrategy>> AttackCombinations { get; set; }
    }
}
