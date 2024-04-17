using CarFactory.Models.Engines;

namespace CarFactory.Models.Suspensions;

public static class SuspensionFactory
{
    public static ISuspension CreateSuspension()
    {
        Console.WriteLine("Выберите тип подвески для вашей машины:\n" +
            "1 - Стандартная\n" +
            "2 - Спортивная\n" +
            "3 - Пружинная");

        int choise;
        while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 3)
        {
            Console.WriteLine("Некорректный выбор! Попробуйте еще раз");
        }

        Console.Clear();
        return choise switch
        {
            1 => new Standard(),
            2 => new Sport(),
            3 => new Spring(),
            _ => new Standard(),
        };
    }
}
