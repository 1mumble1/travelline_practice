const string Exit = "exit";
const int MinNumber = 1;
const int MaxNumber = 20;
const int MinNumberForWin = 17;
const int MaxNumberForWin = 21;
const int Multiplicator = 2;

int balance = 10000;
Random random = new();

while (true)
{
    Console.Clear();
    Console.WriteLine($"Ваш текущий баланс: {balance}");
    if (balance <= 0)
    {
        Console.WriteLine("Вам больше не на что делать ставки, игра для вас закончилась(");
        return;
    }

    Console.Write("Введите ставку (введите exit для выхода): ");
    string? betString = Console.ReadLine();
    if (betString == Exit)
    {
        Console.WriteLine("До свидания!");
        return;
    }

    if (!int.TryParse(betString, out var bet))
    {
        Console.WriteLine("Было введено невалидное значение, попробуйте еще раз!");
        Console.ReadKey();
        continue;
    }

    if (bet < 0 || bet > balance)
    {
        Console.WriteLine("Невозможно сделать такую ставку, попробуйте еще раз!");
        Console.ReadKey();
        continue;
    }

    int randomNumber = random.Next(MinNumber, MaxNumber);

    bool isWinner = (randomNumber is < MaxNumberForWin and > MinNumberForWin);
    if (!isWinner)
    {
        Console.WriteLine("Вы проиграли!");
        Console.ReadKey();
        balance -= bet;
    }
    else
    {
        Console.WriteLine("Вы выиграли!");
        Console.ReadKey();
        balance += bet * (1 + (Multiplicator * randomNumber % MaxNumberForWin));
    }
}
