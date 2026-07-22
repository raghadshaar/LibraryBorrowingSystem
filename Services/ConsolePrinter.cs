namespace LibrarySystem.services;

public static class ConsolePrinter
{
    public static void PrintBook(Book book)
    {
        Console.WriteLine(
            $"{book.Id} - " +
            $"{book.Title} - " +
            $"{book.Author} - " +
            $"{book.ISBN} - " +
            $"{book.AvailabilityStatus}");
    }

    public static void PrintBooks(
        IEnumerable<Book> books,
        string emptyMessage)
    {
        bool hasBooks = false;

        foreach (Book book in books)
        {
            PrintBook(book);
            hasBooks = true;
        }

        if (!hasBooks)
        {
            Console.WriteLine(emptyMessage);
        }
    }

    public static void PrintBorrowRecords(
        IEnumerable<BorrowRecord> records)
    {
        bool hasRecords = false;

        foreach (BorrowRecord record in records)
        {
            Console.WriteLine(
                $"{record.Member?.Name} borrowed " +
                $"{record.Book?.Title} | " +
                $"Due: {record.DueDate:d} | " +
                $"Returned: {record.IsReturned}");

            hasRecords = true;
        }

        if (!hasRecords)
        {
            Console.WriteLine("No borrow records.");
        }
    }
}