namespace LibrarySystem
{
    internal class Program
    {
        static Library library = new Library();

        static void Main(string[] args)
        {
            SeedBooks();

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
                Console.WriteLine("8 - Exit");
                Console.Write("Choose option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(true);
                        break;

                    case "2":
                        AddBook(false);
                        break;

                    case "3":
                        RegisterMember();
                        break;

                    case "4":
                        BorrowBook();
                        break;

                    case "5":
                        ReturnBook();
                        break;

                    case "6":
                        ViewAvailableBooks();
                        break;

                    case "7":
                        ViewBorrowRecords();
                        break;

                    case "8":
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

        static void AddBook(bool isPhysical)
        {
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter title: ");
            string? title = Console.ReadLine();

            Console.Write("Enter author: ");
            string? author = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            string? isbn = Console.ReadLine();

            Book book = isPhysical ? new PhysicalBook() : new EBook();

            book.Id = id;
            book.Title = title;
            book.Author = author;
            book.ISBN = isbn;
            book.AvailabilityStatus = AvailabilityStatus.Available;

            library.AddBook(book);

            Console.WriteLine("Book added.");
        }

        static void RegisterMember()
        {
            Console.Write("Enter member id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter email: ");
            string? email = Console.ReadLine();

            Member member = new Member
            {
                Id = id,
                Name = name,
                Email = email
            };

            library.RegisterMember(member);

            Console.WriteLine("Member registered.");
        }

        static void BorrowBook()
        {
            Console.Write("Enter member id: ");
            int memberId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter book id: ");
            int bookId = int.Parse(Console.ReadLine()!);

            bool result = library.BorrowBook(memberId, bookId);

            Console.WriteLine(result
                ? "Book borrowed successfully."
                : "Borrow failed. Check member id, book id, or availability.");
        }

        static void ReturnBook()
        {
            Console.Write("Enter member id: ");
            int memberId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter book id: ");
            int bookId = int.Parse(Console.ReadLine()!);

            bool result = library.ReturnBook(memberId, bookId);

            Console.WriteLine(result
                ? "Book returned successfully."
                : "Return failed. No active borrow record found.");
        }

        static void ViewAvailableBooks()
        {
            var books = library.GetAvailableBooks();

            if (!books.Any())
            {
                Console.WriteLine("No available books.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id} - {book.Title} - {book.Author} - {book.AvailabilityStatus}");
            }
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
                Console.WriteLine($"{record.Member.Name} borrowed {record.Book.Title} | Due: {record.DueDate:d} | Returned: {record.IsReturned}");
            }
        }
    }
}