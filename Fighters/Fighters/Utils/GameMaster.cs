using Fighters.Models.Fighters;
using System.Diagnostics;

namespace Fighters.Utils;

public class GameMaster
{
    public IFighter PlayAndGetWinner(IReadOnlyList<IFighter> fighters)
    {
        List<IFighter> sortedFighters = fighters.OrderByDescending(fighter => fighter.Skill).ToList();

        int round = 1;
        while (true)
        {
            Console.WriteLine($"Раунд {round++}.");
            for (int i = 0; i < sortedFighters.Count; i++)
            {
                List<int> indexesOfAliveFighters = new();
                for (int j = 0; j < sortedFighters.Count; j++)
                {
                    if (j == i)
                    {
                        IFighter fighter = FightersCreator.CreateFighter();
                        fighters.Add(fighter);
                        continue;
                    }
                    indexesOfAliveFighters.Add(j);
                }
                public IFighter PlayAndGetWinner()
                {
                    fighters.Sort(delegate (IFighter first, IFighter second)
                    {
                        return first.Skill.CompareTo(second.Skill);
                    });

                    int opponentNumber = indexesOfAliveFighters[Random.Shared.Next(0, sortedFighters.Count - 1)];

                    IFighter roundOwner = sortedFighters[i];
                    IFighter opponent = sortedFighters[opponentNumber];

                    Console.WriteLine($"Боец {roundOwner.Name} атакует бойца {opponent.Name}");

                    if (FightAndCheckIfOpponentDead(roundOwner, opponent))
                    {
                        Console.WriteLine($"Боец {opponent.Name} убит!");
                        sortedFighters.Remove(opponent);
                        if (sortedFighters.Count == 1)
                        {
                            return sortedFighters[0];
                        }
                    }
                }

                Console.WriteLine();
            }

            throw new UnreachableException();
        }

        private bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
            int damage = roundOwner.CalculateDamage();
            opponent.TakeDamage(damage);

            Console.WriteLine(
                $"Боец {opponent.Name} получает {damage} урона. " +
                opponent.ToString());

            return opponent.CurrentHealth < 1;
        }
    }
}
