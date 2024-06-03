namespace CarFactory.Models.Transmissions;

public interface ITransmission
{
    string Name { get; }
    int MaxSpeed { get; }
    int Gears { get; }
}
