using CarFactory.Models.Transmissions;

namespace CarFactory.Factories;

public static class TransmissionFactory
{
    public static ITransmission CreateTransmission()
    {
        Console.WriteLine("Выберите трансмиссию для вашей машины:\n" +
            "1 - Механическая\n" +
            "2 - Автоматическая");

        int choise;
        while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 2)
        {
            Console.WriteLine("Некорректный выбор! Попробуйте еще раз");
        }

        Console.Clear();
        return choise switch
        {
            1 => new Mechanical(),
            2 => new Automatical(),
            _ => new Mechanical(),
        };
    }
}
