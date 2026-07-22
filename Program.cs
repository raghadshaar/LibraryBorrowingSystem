namespace LibrarySystem
{
    internal class Program
    {
        static Library library = new Library();
        static void Main(string[] args)
        {
            SeedBooks();
            BookService bookService = new BookService(library);
            var memberService = new MemberService(library);
            var borrowingService = new BorrowingService(library);
            bool running = true;

            while (running)
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

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bookService.AddEBook();
                        break;

                    case "2":
                        bookService.AddPhysicalBook();
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

        static void SeedBooks()
        {
            library.AddBook(new PhysicalBook { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "9780132350884", AvailabilityStatus = AvailabilityStatus.Available });
            library.AddBook(new PhysicalBook { Id = 2, Title = "Design Patterns", Author = "Erich Gamma", ISBN = "9780201633610", AvailabilityStatus = AvailabilityStatus.Available });
            library.AddBook(new EBook { Id = 3, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", ISBN = "9780135957059", AvailabilityStatus = AvailabilityStatus.Available });
            library.AddBook(new PhysicalBook { Id = 4, Title = "Refactoring", Author = "Martin Fowler", ISBN = "9780134757599", AvailabilityStatus = AvailabilityStatus.Available });
            library.AddBook(new EBook { Id = 5, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", ISBN = "9780262046305", AvailabilityStatus = AvailabilityStatus.Available });
        }

      
        
    }
      
}