const string Yes = "y";
const int DeliveryTime = 3;

Console.Write("Введите название товара: ");
string? product = Console.ReadLine();

Console.Write("Введите кол-во товара: ");
string? countString = Console.ReadLine();
bool isCount = int.TryParse(countString, out int count);
if (!isCount)
{
    Console.WriteLine("Невалидное число товара!");
    return;
}

Console.Write("Введите ваше имя: ");
string? name = Console.ReadLine();

Console.Write("Введите адрес: ");
string? address = Console.ReadLine();

Console.WriteLine($"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (y/n)");
string? confirmationInput = Console.ReadLine();
if (confirmationInput != Yes)
{
    Console.WriteLine("Заказ отменен.");
    return;
}

Console.WriteLine($"{name}!");
Console.WriteLine($"Ваш заказ {product} в количестве {count} оформлен!");

DateTime todaysDate = DateTime.Today;
DateTime dateOfDelivery = todaysDate.AddDays(DeliveryTime);
Console.WriteLine($"Ожидайте доставку по адресу {address} к {dateOfDelivery}");
