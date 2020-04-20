namespace Projekt3
{
    class DodgeDefendStrategy : IEntityDefendStrategy
    {
        public bool Defend()
        {
            return RandomNumberProvider.GetNumber(4) == 0;
        }
    }
}
