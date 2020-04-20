using System;
using System.Collections.Generic;

namespace Projekt3
{
    class Duel
    {
        private IEntity entity1;
        private IEntity entity2;

        public Duel(IEntity entity1, IEntity entity2)
        {
            this.entity1 = entity1;
            this.entity2 = entity2;
        }

        public void Start()
        {
            var entities = new[]
            {
                this.entity1,
                this.entity2
            };

            for (int i = 0, round = 1; entities[0].Health > 0 && entities[1].Health > 0; i++)
            {
                var attacker = entities[i % 2];
                var defender = entities[(i + 1) % 2];

                Queue<IEntityAttackStrategy> attacks;

                if (i % 2 == 0)
                {
                    attacks = GetAttackQueue(attacker);

                    Console.WriteLine();
                    Console.WriteLine($"----[ Round {round++} ]----");
                    Console.WriteLine();
                }
                else
                {
                    attacks = new Queue<IEntityAttackStrategy>();
                    attacks.Enqueue(attacker.AttackStrategy);
                }

                bool isCombination = attacks.Count > 1;
                bool isCriticalHit = true;

                while (attacks.Count > 0)
                {
                    var attack = attacks.Dequeue().Attack();
                    var defend = defender.DefendStrategy.Defend();

                    if (defend && attack.ShouldBreakDefence || !defend)
                    {
                        double damageMultiplier = 1;
                        string damageMultiplierText = String.Empty;

                        if (isCombination && isCriticalHit && attacks.Count == 0)
                        {
                            damageMultiplier = 2;
                            damageMultiplierText = " (Critical hit)";
                        }

                        double damage = attack.Damage * damageMultiplier;

                        defender.Health = Math.Max(defender.Health - damage, 0);

                        Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {damage} HP.{damageMultiplierText}");
                    }
                    else
                    {
                        isCriticalHit = false;
                        Console.WriteLine($"{defender.Name} blocks the attack.");
                    }
                }

                PrintRoundStatistics();
            }

            PrintFightStatistics();
        }

        private void PrintRoundStatistics()
        {
            Console.WriteLine();
            Console.WriteLine($"{"Name".PadRight(20)} HP");
            Console.WriteLine($"{this.entity1.Name.PadRight(20)} {new String('#', (int)(this.entity1.Health / 100 * 10)).PadRight(10)} {this.entity1.Health.ToString().PadLeft(3)} HP");
            Console.WriteLine($"{this.entity2.Name.PadRight(20)} {new String('#', (int)(this.entity2.Health / 100 * 10)).PadRight(10)} {this.entity2.Health.ToString().PadLeft(3)} HP");
            Console.WriteLine();
        }

        private void PrintFightStatistics()
        {
            Console.WriteLine("Status after fight");
            PrintRoundStatistics();
        }

        private Queue<IEntityAttackStrategy> GetAttackQueue(IEntity entity)
        {
            Console.WriteLine("What attack you want to perform:");
            Console.WriteLine("1. Default attack");

            int index = 2;

            var attacks = new Queue<IEntityAttackStrategy>();
            var attacksPairs = new Dictionary<string, string>();

            foreach (var combination in entity.AttackCombinations)
            {
                attacksPairs.Add(index.ToString(), combination.Key);

                Console.WriteLine($"{index++}. {combination.Key}");
            }

            string choice = Console.ReadLine();

            Console.Clear();

            if (choice == "1")
            {
                attacks.Enqueue(entity.AttackStrategy);
            }
            else
            {
                if (attacksPairs.ContainsKey(choice))
                {
                    foreach (var strategy in entity.AttackCombinations[attacksPairs[choice]])
                    {
                        attacks.Enqueue(strategy);
                    }
                }
            }

            return attacks;
        }
    }
}
