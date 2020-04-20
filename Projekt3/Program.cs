// Klasy, dziedziczenie, interfejsy
// Dictionary, Queue, List

using System;
using System.Collections.Generic;

namespace Projekt3
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player("Player");
            var monster = new Monster("Monster");

            // Create all needed strategies

            var fastAttackStrategy = new FastAttackStrategy();
            var strongAttackStrategy = new StrongAttackStrategy();
            var dodgeDefendStrategy = new DodgeDefendStrategy();

            // Set default attack / defence strategies for entities

            player.AttackStrategy = fastAttackStrategy;
            player.DefendStrategy = dodgeDefendStrategy;

            monster.AttackStrategy = strongAttackStrategy;
            monster.DefendStrategy = dodgeDefendStrategy;

            // Set attack combinations that player can perform. If all attacks from combination are successfull, the last hit is critical (50% damage boost)

            player.CreateAttackCombination("fast-strong-fast", new List<IEntityAttackStrategy>()
            {
                fastAttackStrategy,
                strongAttackStrategy,
                fastAttackStrategy
            });

            player.CreateAttackCombination("strong-fast-strong", new List<IEntityAttackStrategy>()
            {
                strongAttackStrategy,
                fastAttackStrategy,
                strongAttackStrategy
            });

            // Start duel

            var duel = new Duel(player, monster);

            duel.Start();

            Console.ReadKey();
        }
    }
}
