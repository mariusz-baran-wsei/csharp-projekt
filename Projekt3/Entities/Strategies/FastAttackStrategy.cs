namespace Projekt3
{
    class FastAttackStrategy : IEntityAttackStrategy
    {
        public AttackDto Attack()
        {
            AttackDto attackDto = new AttackDto
            {
                Damage = RandomNumberProvider.GetNumber(10) + 10,
                ShouldBreakDefence = RandomNumberProvider.GetNumber(8) == 0
            };

            return attackDto;
        }
    }
}
