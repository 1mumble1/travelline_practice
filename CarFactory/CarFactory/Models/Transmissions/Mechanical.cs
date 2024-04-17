namespace CarFactory.Models.Transmissions;

public class Mechanical : ITransmission
{
    public string Name => "Механическая";
    public int MaxSpeed => 40;
    public int Gears => 5;
}
