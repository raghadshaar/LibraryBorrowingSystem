namespace LibrarySystem.services;

public class BorrowingService
{
    private readonly Library _library;

    public BorrowingService(Library library)
    {
        _library = library;
    }

    public void BorrowBook()
    {
        if (!TryReadMemberAndBookIds(
                out int memberId,
                out int bookId))
        {
            return;
        }

        bool isBorrowed =
            _library.BorrowBook(memberId, bookId);

        Console.WriteLine(
            isBorrowed
                ? "Book borrowed successfully."
                : "Borrow failed. Check member ID, book ID, or availability.");
    }

    public void ReturnBook()
    {
        if (!TryReadMemberAndBookIds(
                out int memberId,
                out int bookId))
        {
            return;
        }

        bool isReturned =
            _library.ReturnBook(memberId, bookId);

        Console.WriteLine(
            isReturned
                ? "Book returned successfully."
                : "Return failed. No active borrow record found.");
    }

    public void ViewBorrowRecords()
    {
        var records = _library.GetBorrowRecords();

        ConsolePrinter.PrintBorrowRecords(records);
    }

    private static bool TryReadMemberAndBookIds(
        out int memberId,
        out int bookId)
    {
        Console.Write("Enter member ID: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out memberId))
        {
            Console.WriteLine("Invalid member ID.");

            bookId = 0;
            return false;
        }

        Console.Write("Enter book ID: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out bookId))
        {
            Console.WriteLine("Invalid book ID.");
            return false;
        }

        return true;
    }
}