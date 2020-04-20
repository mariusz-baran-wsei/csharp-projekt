namespace Projekt3
{
    class StrongAttackStrategy : IEntityAttackStrategy
    {
        public AttackDto Attack()
        {
            AttackDto attackDto = new AttackDto
            {
                Damage = RandomNumberProvider.GetNumber(15) + 25,
                ShouldBreakDefence = RandomNumberProvider.GetNumber(4) == 0
            };

            return attackDto;
        }
    }
}
