const string BALANCE = "Your balance: ";
const string READ_BET = "Введите ставку (введите exit для выхода): ";
const string EXIT = "exit";
const string GOODBYE = "До свидания!";
const string NOT_VALID_VALUE = "Было введено невалидное значение, попробуйте еще раз!";
const string NOT_VALID_BET = "Невозможно сделать такую ставку, попробуйте еще раз!";
const string LOSE = "Вы проиграли!";
const string WIN = "Вы выиграли!";
const int MIN_NUMBER = 1;
const int MAX_NUMBER = 20;
const int MIN_NUMBER_WIN = 17;
const int MAX_NUMBER_WIN = 21;
const int MULTIPLICATOR = 2;

int balance = 10000;
Random random = new Random();
string betString;

while (true)
{
    Console.Clear();
    Console.WriteLine(BALANCE + balance);
    Console.Write(READ_BET);
    betString = Console.ReadLine();
    if (betString == EXIT)
    {
        Console.WriteLine(GOODBYE);
        return;
    }

    bool result = int.TryParse(betString, out var bet);
    if (!result)
    {
        Console.WriteLine(NOT_VALID_VALUE);
        Console.ReadKey();
        continue;
    }

    if (bet < 0 || bet > balance)
    {
        Console.WriteLine(NOT_VALID_BET);
        Console.ReadKey();
        continue;
    }

    int randomNumber = random.Next(MIN_NUMBER, MAX_NUMBER);

    bool win = (randomNumber < MAX_NUMBER_WIN && randomNumber > MIN_NUMBER_WIN);
    if (!win)
    {
        Console.WriteLine(LOSE);
        Console.ReadKey();
        balance -= bet;
    }
    else
    {
        Console.WriteLine(WIN);
        Console.ReadKey();
        balance += bet * (1 + (MULTIPLICATOR * randomNumber % MIN_NUMBER_WIN));
    }
}
