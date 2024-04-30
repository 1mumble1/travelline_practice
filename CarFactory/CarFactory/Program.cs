using CarFactory.Models.Cars;

namespace CarFactory;
public class Program
{
    private const string Yes = "y";
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать на фабрику машин!");

        while (true)
        {
            Console.WriteLine("Давайте соберем для вас машину");

            ICar car = CarFactory.Factories.CarFactory.CreateCar();

            Console.WriteLine("Характеристики вашей машины:");
            Console.WriteLine(car.ToString());

            Console.WriteLine("Хотите собрать еще одну машину? (введите y для потверждения и любую клавишу для завершения)");
            string? confirmationInput = Console.ReadLine();
            Console.Clear();
            if (confirmationInput == Yes)
            {
                continue;
            }

            Console.WriteLine("До свидания!");
            break;
        }
    }
}