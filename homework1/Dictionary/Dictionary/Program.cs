const string FAILURE_READ_DICTIONARY = "Ошибка чтения из словаря следующей строки: ";
const string IGNORE_LINE = "Чтение будет продолжено дальше, строка проигнорирована";
const string READ_WORD = "Введите слово для поиска перевода в словаре (введите exit для выхода): ";
const string DICTIONARY_IS_EMPTY = "Словарь пуст: не удастся найти перевод. До свидания!";
const string NOT_FOUND = "Слово не было найдено.";
const string GOODBYE = "До свидания!";
const string FILE_NAME = @"C:\MRT47\dict.txt";
const string EXIT = "exit";
const char SPACE = ' ';

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

using (StreamReader reader = new StreamReader(FILE_NAME))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        string[] words = line.Split(new char[] { SPACE }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length != 2)
        {
            Console.WriteLine(FAILURE_READ_DICTIONARY + line);
            Console.WriteLine(IGNORE_LINE);
            Console.ReadKey();
            continue;
        }

        string word = words[0], translate = words[1];
        dictionary.Add(word, translate);
    }
}

if (dictionary.Count < 0)
{
    Console.WriteLine(DICTIONARY_IS_EMPTY);
    return;
}

while (true)
{
    Console.Clear();
    Console.Write(READ_WORD);
    string word = Console.ReadLine();

    if (word == EXIT)
    {
        Console.Write(GOODBYE);
        return;
    }

    string translate;
    bool existKey = dictionary.TryGetValue(word, out translate);
    if (existKey)
    {
        Console.WriteLine(translate);
        Console.ReadKey();
        continue;
    }

    bool existValue = dictionary.ContainsValue(word);
    if (existValue)
    {
        Console.WriteLine(FindByValue(word, dictionary));
        Console.ReadKey();
        continue;
    }

    Console.WriteLine(NOT_FOUND);
    Console.ReadKey();
}