using CarFactory.Models.BodyShapes;

namespace CarFactory.Models.Colors;

public static class ColorFactory
{
    public static IColor CreateColor()
    {
        Console.WriteLine("Выберите цвет кузова для вашей машины:\n" +
            "1 - Черный\n" +
            "2 - Синий\n" +
            "3 - Красный\n" +
            "4 - Белый");

        int choise;
        while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 4)
        {
            Console.WriteLine("Некорректный выбор! Попробуйте еще раз");
        }

        Console.Clear();
        return choise switch
        {
            1 => new Black(),
            2 => new Blue(),
            3 => new Red(),
            4 => new White(),
            _ => new Black(),
        };
    }
}
