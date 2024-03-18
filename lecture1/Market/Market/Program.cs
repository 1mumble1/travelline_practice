const string READ_PRODUCT = "Введите название товара: ";
const string READ_COUNT = "Введите кол-во товара: ";
const string FAILURE_READ_COUNT = "Невалидное число товара!";
const string READ_NAME = "Введите ваше имя: ";
const string READ_ADDRESS = "Введите адрес: ";
const string YES = "y";
const string FAILURE_DELIVERY = "Заказ отменен.";
const int DELIVERY_TIME = 3;

Console.Write(READ_PRODUCT);
string product = Console.ReadLine();

Console.Write(READ_COUNT);
var countString = Console.ReadLine();
bool isCount = int.TryParse(countString, out int count);
if (!isCount)
{
    Console.WriteLine(FAILURE_READ_COUNT);
    return;
}

Console.Write(READ_NAME);
string name = Console.ReadLine();

Console.Write(READ_ADDRESS);
string address = Console.ReadLine();

Console.WriteLine($"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (y/n)");
var yes = Console.ReadLine();
if (yes != YES)
{
    Console.WriteLine(FAILURE_DELIVERY);
    return;
}
Console.WriteLine($"{name}!");
Console.WriteLine($"Ваш заказ {product} в количестве {count} оформлен!");

DateTime todaysDate = DateTime.Today;
DateTime dateOfDelivery = todaysDate.AddDays(DELIVERY_TIME);
Console.WriteLine($"Ожидайте доставку по адресу {address} к {dateOfDelivery}");
