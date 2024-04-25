using Fighters.Models.Fighters;

namespace Fighters
{
    public class GameMaster
    {
        private const string AddFighter = "add-fighter";
        private const string Play = "play";
        private List<IFighter> fighters = new List<IFighter>();
        public void CommandHandler()
        {
            while (true)
            {
                Console.WriteLine("Введите команду:");
                Console.WriteLine("add-fighter - Добавить нового бойца на арену");
                Console.WriteLine("play - Начать битву");
                string? commandInput = Console.ReadLine();
                if (commandInput == null || (commandInput != AddFighter && commandInput != Play))
                {
                    Console.WriteLine("Неизвестная команда, попробуйте еще раз");
                    continue;
                }

                if (commandInput == Play)
                {
                    if (fighters.Count < 2)
                    {
                        Console.WriteLine("Вы создали недостаточно бойцов для игры!");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (commandInput == AddFighter)
                {
                    IFighter fighter = FightersCreator.CreateFighter();
                    fighters.Add(fighter);
                    continue;
                }
            }
        }
        public IFighter PlayAndGetWinner()
        {
            fighters.Sort(delegate(IFighter first, IFighter second)
            {
                return first.Skill.CompareTo(second.Skill);
            });

            int round = 1;
            while (true)
            {
                Console.WriteLine($"Раунд {round++}.");
                for (int i = 0; i < fighters.Count; i++)
                {
                    int opponentNumber = Random.Shared.Next(0, fighters.Count);
                    while (opponentNumber == i)
                    {
                        opponentNumber = Random.Shared.Next(0, fighters.Count);
                    }

                    IFighter roundOwner = fighters[i];
                    IFighter opponent = fighters[opponentNumber];

                    Console.WriteLine($"Боец {roundOwner.Name} атакует бойца {opponent.Name}");

                    if (FightAndCheckIfOpponentDead(roundOwner, opponent))
                    {
                        Console.WriteLine($"Боец {opponent.Name} убит!");
                        fighters.Remove(opponent);
                        if (fighters.Count == 1)
                        {
                            return fighters[0];
                        }
                    }
                }

                Console.WriteLine();
            }
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
