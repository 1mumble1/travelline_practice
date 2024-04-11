const string Exit = "exit";
const char Space = ' ';
const string path = @"..\..\..\dictionary.txt";

string? FindByValue(string value, Dictionary<string, string> dictionary)
{
    foreach (KeyValuePair<string, string> pair in dictionary)
    {
        if (dictionary[pair.Key] == value)
        {
            return pair.Key;
        }
    }
    return null;
}

Dictionary<string, string> dictionary = new Dictionary<string, string>();

using (StreamReader reader = new StreamReader(path))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        string[] words = line.Split(new char[] { Space }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length != 2)
        {
            Console.WriteLine($"Ошибка чтения из словаря следующей строки: {line}");
            Console.WriteLine("Чтение будет продолжено дальше, строка проигнорирована");
            Console.ReadKey();
            continue;
        }

        string word = words[0], translate = words[1];
        dictionary.Add(word, translate);
    }
}

if (dictionary.Count < 0)
{
    Console.WriteLine("Словарь пуст: не удастся найти перевод.До свидания!");
    return;
}

while (true)
{
    Console.Clear();
    Console.Write("Введите слово для поиска перевода в словаре (введите exit для выхода): ");
    string? word = Console.ReadLine();

    if (word == Exit || word == null)
    {
        Console.WriteLine("До свидания!");
        return;
    }

    string? translate = dictionary.FirstOrDefault(pair => pair.Key == word).Value;
    if (translate != null)
    {
        Console.WriteLine($"Перевод слова '{word}' с английского на русский: '{translate}'");
        Console.ReadKey();
        continue;
    }

    translate = dictionary.FirstOrDefault(pair => pair.Value == word).Key;
    if (translate != null)
    {
        Console.WriteLine($"Перевод слова '{word}' с русского на английский: '{translate}'");
        Console.ReadKey();
        continue;
    }

    Console.WriteLine($"Слово '{word}' не было найдено.");
    Console.ReadKey();
}