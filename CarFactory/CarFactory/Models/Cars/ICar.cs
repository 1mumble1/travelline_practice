using CarFactory.Models.BodyShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Suspensions;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars;

public interface ICar
{
    string Name { get; }
    int MaxSpeed { get; }
    int Gears { get; }
    IBodyShape BodyShape { get; }
    IColor Color { get; }
    IEngine Engine { get; }
    ISuspension Suspension { get; }
    ITransmission Transmission { get; }
}
