using Fighters.Models.Fighters;

namespace Fighters;

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
            if (commandInput is null || (commandInput != AddFighter && commandInput != Play))
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
        List<IFighter> sortedFighters = fighters.OrderByDescending(fighter => fighter.Skill).ToList();

        int round = 1;
        while (true)
        {
            Console.WriteLine($"Раунд {round++}.");
            for (int i = 0; i < sortedFighters.Count; i++)
            {
                int opponentNumber = Random.Shared.Next(0, sortedFighters.Count);
                while (opponentNumber == i)
                {
                    opponentNumber = Random.Shared.Next(0, sortedFighters.Count);
                }

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
