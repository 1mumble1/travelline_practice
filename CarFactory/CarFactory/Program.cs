using CarFactory.Models.Cars;

public class Program
{
    private const string Yes = "y";
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать на фабрику машин!");
        
        while (true)
        {
            Console.WriteLine("Давайте соберем для вас машину");

            ICar car = CarMaker.CreateCar();

            Console.WriteLine("Характеристики вашей машины:");
            Console.WriteLine(car.ToString());
            Console.WriteLine("Хотите собрать еще одну машину? (Press Enter to exit, y to confirm)");
            string? confirmationInput = Console.ReadLine();
            Console.Clear();
            if (confirmationInput == Yes)
            {
                continue;
            }
            else
            {
                Console.WriteLine("До свидания!");
                break;
            }
        }
    }
}