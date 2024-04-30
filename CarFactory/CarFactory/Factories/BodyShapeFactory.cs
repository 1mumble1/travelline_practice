using CarFactory.Models.BodyShapes;

namespace CarFactory.Factories;

public static class BodyShapeFactory
{
    public static IBodyShape CreateBodyShape()
    {
        Console.WriteLine("Выберите тип кузова для вашей машины:\n" +
            "1 - Седан\n" +
            "2 - Хэтчбэк\n" +
            "3 - Купе\n" +
            "4 - Внедорожник");

        int choise;
        while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 4)
        {
            Console.WriteLine("Некорректный выбор! Попробуйте еще раз");
        }

        Console.Clear();
        return choise switch
        {
            1 => new Sedan(),
            2 => new Hatchback(),
            3 => new Coupe(),
            4 => new OffRoader(),
            _ => new Sedan(),
        };
    }
}
