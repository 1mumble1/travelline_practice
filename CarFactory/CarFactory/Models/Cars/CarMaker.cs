using CarFactory.Models.BodyShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Suspensions;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars;

public static class CarMaker
{
    public static ICar CreateCar()
    {
        Console.WriteLine("Введите название для вашей машины: (например, Lada Vesta)");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Некорректное название для вашей машины! Попробуйте еще раз");
            name = Console.ReadLine();
        }

        IBodyShape bodyShape = BodyShapeFactory.CreateBodyShape();
        IColor color = ColorFactory.CreateColor();
        IEngine engine = EngineFactory.CreateEngine();
        ITransmission transmission = TransmissionFactory.CreateTransmission();
        ISuspension suspension = SuspensionFactory.CreateSuspension();

        return new Car(name, bodyShape, color, engine, suspension, transmission);
    }
}
