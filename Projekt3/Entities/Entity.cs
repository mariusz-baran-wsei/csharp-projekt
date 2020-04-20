using System.Collections.Generic;

namespace Projekt3
{
    abstract class Entity : IEntity
    {
        public double Health { get; set; } = 100.0;
        public string Name { get; set; }
        public IEntityAttackStrategy AttackStrategy { get; set; }
        public IEntityDefendStrategy DefendStrategy { get; set; }
        public Dictionary<string, List<IEntityAttackStrategy>> AttackCombinations { get; set; } = new Dictionary<string, List<IEntityAttackStrategy>>();

        public Entity(string name)
        {
            this.Name = name;
        }

        public virtual void CreateAttackCombination(string name, List<IEntityAttackStrategy> attacks)
        {
            this.AttackCombinations.Add(name, attacks);
        }
    }
}
