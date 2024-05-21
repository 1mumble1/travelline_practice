// удален лишний using
using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    // по совету IDE сделано поле readonly
    private static readonly BookingService _bookingService = new();
    // по совету IDE сделано поле readonly, исправлено new() -> []
    private static readonly Dictionary<int, ICommand> _executedCommands = [];
    // исправлено название приватной переменной s_commandIndex -> _commandIndex
    private static int _commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        // добавлена обработка null string
        string? input;
        while ((input = Console.ReadLine() ?? "") != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];
        DateTime startDate, endDate;
        Guid bookingId;

        switch (commandName)
        {
            case "book":
                // выброс ошибки, вместо console.writeline
                if (parts.Length != 6)
                {
                    throw new ArgumentException("Invalid number of arguments for booking. " +
                        "Expected format: 'book <UserId> <Category> <StartDate> <EndDate> <Currency>'.");
                }

                // проверка валидного user Id
                if (!int.TryParse(parts[1], out int userId))
                {
                    throw new ArgumentException("Invalid user id for booking. It must be a number.");
                }

                // проверка валидной даты заезда
                if (!DateTime.TryParse(parts[3], out startDate))
                {
                    throw new ArgumentException("Invalid start date for booking. Usage: dd/mm/yyyy.");
                }

                // проверка валидной даты выезда
                if (!DateTime.TryParse(parts[4], out endDate))
                {
                    throw new ArgumentException("Invalid end date for booking. Usage: dd/mm/yyyy.");
                }

                // проверка валидной валюты
                if (!Enum.TryParse(parts[5], true, out CurrencyDto currency))
                {
                    throw new ArgumentException($"Invalid currency for booking. Usage: {string.Join(", ", Enum.GetNames(typeof(CurrencyDto)))}.");
                }

                BookingDto bookingDto = new()
                {
                    UserId = userId,
                    Category = parts[2],
                    StartDate = startDate,
                    EndDate = endDate,
                    Currency = currency,
                };

                BookCommand bookCommand = new(_bookingService, bookingDto);
                bookCommand.Execute();
                _executedCommands.Add(++_commandIndex, bookCommand);
                Console.WriteLine("Booking command run is successful.");

                break;

            case "cancel":
                // выброс ошибки, вместо console.writeline
                if (parts.Length != 2)
                {
                    throw new ArgumentException("Invalid number of arguments for cancel. " +
                        "Expected format: 'cancel <BookingId>'.");
                }

                // исправлен парсинг guid
                if (!Guid.TryParse(parts[1], out bookingId))
                {
                    throw new ArgumentException("Invalid guid of booking.");
                }
                CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                cancelCommand.Execute();
                _executedCommands.Add(++_commandIndex, cancelCommand);
                Console.WriteLine("Cancellation command run is successful.");
                break;

            case "undo":
                // проверка на пустую историю команд
                if (_executedCommands.Count == 0)
                {
                    throw new Exception("The history of executed commands is empty.");
                }
                _executedCommands[_commandIndex].Undo();
                _executedCommands.Remove(_commandIndex);
                _commandIndex--;
                Console.WriteLine("Last command undone.");

                break;

            case "find":
                // выброс ошибки, вместо console.writeline
                if (parts.Length != 2)
                {
                    throw new ArgumentException("Invalid number of arguments for booking." +
                        "Expected format: 'find <BookingId>'.");
                }

                // исправлен парсинг guid
                if (!Guid.TryParse(parts[1], out bookingId))
                {
                    throw new ArgumentException("Invalid guid of booking.");
                }
                FindBookingByIdCommand findCommand = new(_bookingService, bookingId);
                findCommand.Execute();
                break;

            case "search":
                // выброс ошибки, вместо console.writeline
                if (parts.Length != 4)
                {
                    Console.WriteLine("Invalid arguments for 'search'." +
                        "Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                    return;
                }

                // проверка валидной даты заезда
                if (!DateTime.TryParse(parts[1], out startDate))
                {
                    throw new ArgumentException("Invalid start date for booking. Usage: dd/mm/yyyy.");
                }

                // проверка валидной даты выезда
                if (!DateTime.TryParse(parts[2], out endDate))
                {
                    throw new ArgumentException("Invalid end date for booking. Usage: dd/mm/yyyy.");
                }

                string categoryName = parts[3];
                SearchBookingsCommand searchCommand = new(_bookingService, startDate, endDate, categoryName);
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
