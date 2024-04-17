using CarFactory.Models.BodyShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Suspensions;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars;

public class Car : ICar
{
    public string Name { get; private set; }
    public int MaxSpeed => Engine.MaxSpeed + Transmission.MaxSpeed;
    public int Gears => Transmission.Gears;
    public IBodyShape BodyShape { get; private set; }
    public IColor Color { get; private set; }
    public IEngine Engine { get; private set; }
    public ISuspension Suspension { get; private set;} 
    public ITransmission Transmission { get; private set; }

    public Car (string name,
        IBodyShape bodyShape,
        IColor color,
        IEngine engine,
        ISuspension suspension,
        ITransmission transmission)
    {
        Name = name;
        BodyShape = bodyShape;
        Color = color;
        Engine = engine;
        Suspension = suspension;
        Transmission = transmission;
    }

    public override string ToString()
    {
        return $"Название машины: {Name}\n" +
            $"Форма кузова: {BodyShape.Name}\n" +
            $"Цвет кузова: {Color.Name}\n" +
            $"Двигатель: {Engine.Name}\n" +
            $"Максимальная скорость: {MaxSpeed}\n" +
            $"Трансмиссия: {Transmission.Name}\n" +
            $"Количество передач: {Gears}\n" +
            $"Тип подвески: {Suspension.Name}\n";
    }
}
