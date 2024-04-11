using Fighters.Models.Fighters;
using Fighters.Models.Races;

namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Добро пожаловать в игру Fighters!");

            var master = new GameMaster();
            master.CommandHandler();
            IFighter winner = master.PlayAndGetWinner();
            Console.WriteLine($"Выигрывает {winner.Name}!");
        }
    }
}
