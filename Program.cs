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
                        BorrowBook();
                        break;

                    case "5":
                        ReturnBook();
                        break;

                    case "6":
                        bookService.ViewAvailableBooks();
                        break;

                    case "7":
                        ViewBorrowRecords();
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

        static void BorrowBook()
        {
            Console.Write("Enter member id: ");
            int memberId;


            bool isTrue = int.TryParse(Console.ReadLine()!, out memberId);
            if (!isTrue)
            {
                Console.Write("Invlaid member Id");
                return;
            }

            Console.Write("Enter book id: ");
            int bookId;

            bool isValid = int.TryParse(Console.ReadLine()!, out bookId);
            if (!isValid)
            {
                Console.Write("Invalid book Id");
                return;
            }
            bool result = library.BorrowBook(memberId, bookId);

            Console.WriteLine(result
                ? "Book borrowed successfully."
                : "Borrow failed. Check member id, book id, or availability.");
        }

        static void ReturnBook()
        {
            Console.Write("Enter member id: ");
            int memberId;


            bool isTrue = int.TryParse(Console.ReadLine()!, out memberId);
            if (!isTrue)
            {
                Console.Write("Invlaid member Id");
                return;
            }

            Console.Write("Enter book id: ");
            int bookId;

            bool isValid = int.TryParse(Console.ReadLine()!, out bookId);
            if (!isValid)
            {
                Console.Write("Invalid book Id");
                return;
            }

            bool result = library.ReturnBook(memberId, bookId);

            Console.WriteLine(result
                ? "Book returned successfully."
                : "Return failed. No active borrow record found.");
        }

        static void ViewBorrowRecords()
        {
            var records = library.GetBorrowRecords();

            if (!records.Any())
            {
                Console.WriteLine("No borrow records.");
                return;
            }

            foreach (var record in records)
            {
                Console.WriteLine($"{record.Member?.Name} borrowed {record.Book?.Title} | Due: {record.DueDate:d} | Returned: {record.IsReturned}");
            }
        }
        
        
    }
      
}