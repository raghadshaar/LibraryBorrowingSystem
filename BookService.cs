namespace LibrarySystem;

public class BookService
{
    private readonly Library _library;

    public BookService(Library library)
    {
        _library = library;
    }

    public void AddPhysicalBook()
    {
        AddBook(new PhysicalBook());
    }

    public void AddEBook()
    {
        AddBook(new EBook());
    }

    private void AddBook(Book book)
    {
        Console.Write("Enter ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Book ID must be an integer.");
            return;
        }

        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter author: ");
        string? author = Console.ReadLine();

        Console.Write("Enter ISBN: ");
        string? isbn = Console.ReadLine();

        book.Id = id;
        book.Title = title;
        book.Author = author;
        book.ISBN = isbn;
        book.AvailabilityStatus =
            AvailabilityStatus.Available;

        _library.AddBook(book);

        Console.WriteLine("Book added successfully.");
    }

    public void ViewAvailableBooks()
    {
       IReadOnlyList<Book> books = _library.GetAvailableBooks();

        ConsolePrinter.PrintBooks(
            books,
            "No available books.");
    }

    public void SearchBooks()
    {
        Console.WriteLine("\n===== Search Books =====");
        Console.WriteLine("1 - Search by Title");
        Console.WriteLine("2 - Search by Author");
        Console.WriteLine("3 - Search by ISBN");
        Console.Write("Choose option: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SearchByTitle();
                break;

            case "2":
                SearchByAuthor();
                break;

            case "3":
                SearchByIsbn();
                break;

            default:
                Console.WriteLine("Invalid search option.");
                break;
        }
    }

    private void SearchByTitle()
    {
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        List<Book> books = _library.SearchByTitle(title);

        ConsolePrinter.PrintBooks(
            books,
            "No books found.");
    }

    private void SearchByAuthor()
    {
        Console.Write("Enter author: ");
        string? author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Author cannot be empty.");
            return;
        }

        List<Book> books =
            _library.SearchByAuthor(author);

        ConsolePrinter.PrintBooks(
            books,
            "No books found.");
    }

    private void SearchByIsbn()
    {
        Console.Write("Enter ISBN: ");
        string? isbn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN cannot be empty.");
            return;
        }

        Book? book = _library.SearchByISBN(isbn);

        if (book is null)
        {
            Console.WriteLine("No book found.");
            return;
        }

        ConsolePrinter.PrintBook(book);
    }
}