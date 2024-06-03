namespace CarFactory.Models.Transmissions;

public class Automatical : ITransmission
{
    public string Name => "Автоматическая";
    public int MaxSpeed => 20;
    public int Gears => 6;
}
