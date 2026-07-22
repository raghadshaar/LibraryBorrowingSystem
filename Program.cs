using LibrarySystem.services;

namespace LibrarySystem;

internal static class Program
{
    private static void Main()
    {
        var library = new Library();

        LibrarySeeder.SeedBooks(library);

        var bookService = new BookService(library);
        var memberService = new MemberService(library);
        var borrowingService = new BorrowingService(library);

        bool running = true;

        while (running)
        {
            DisplayMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bookService.AddPhysicalBook();
                    break;

                case "2":
                    bookService.AddEBook();
                    break;

                case "3":
                    memberService.RegisterMember();
                    break;

                case "4":
                    borrowingService.BorrowBook();
                    break;

                case "5":
                    borrowingService.ReturnBook();
                    break;

                case "6":
                    bookService.ViewAvailableBooks();
                    break;

                case "7":
                    borrowingService.ViewBorrowRecords();
                    break;

                case "8":
                    bookService.SearchBooks();
                    break;

                case "9":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\n===== Library Borrowing System =====");
        Console.WriteLine("1 - Add Physical Book");
        Console.WriteLine("2 - Add EBook");
        Console.WriteLine("3 - Register Member");
        Console.WriteLine("4 - Borrow Book");
        Console.WriteLine("5 - Return Book");
        Console.WriteLine("6 - View Available Books");
        Console.WriteLine("7 - View Borrow Records");
        Console.WriteLine("8 - Search Books");
        Console.WriteLine("9 - Exit");
        Console.Write("Choose option: ");
    }
}