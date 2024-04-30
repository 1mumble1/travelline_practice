using CarFactory.Models.Engines;

namespace CarFactory.Factories;

public static class EngineFactory
{
    public static IEngine CreateEngine()
    {
        Console.WriteLine("Выберите двигатель для вашей машины:\n" +
            "1 - Дизельный\n" +
            "2 - Электрический\n" +
            "3 - Бензиновый");

        int choise;
        while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 3)
        {
            Console.WriteLine("Некорректный выбор! Попробуйте еще раз");
        }

        Console.Clear();
        return choise switch
        {
            1 => new Diesel(),
            2 => new Electric(),
            3 => new Petrol(),
            _ => new Petrol(),
        };
    }
}
