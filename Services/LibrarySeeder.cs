namespace LibrarySystem.services;

public static class LibrarySeeder
{
    public static void SeedBooks(Library library)
    {
        library.AddBook(new PhysicalBook
        {
            Id = 1,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            AvailabilityStatus = AvailabilityStatus.Available
        });

        library.AddBook(new PhysicalBook
        {
            Id = 2,
            Title = "Design Patterns",
            Author = "Erich Gamma",
            ISBN = "9780201633610",
            AvailabilityStatus = AvailabilityStatus.Available
        });

        library.AddBook(new EBook
        {
            Id = 3,
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt",
            ISBN = "9780135957059",
            AvailabilityStatus = AvailabilityStatus.Available
        });

        library.AddBook(new PhysicalBook
        {
            Id = 4,
            Title = "Refactoring",
            Author = "Martin Fowler",
            ISBN = "9780134757599",
            AvailabilityStatus = AvailabilityStatus.Available
        });

        library.AddBook(new EBook
        {
            Id = 5,
            Title = "Introduction to Algorithms",
            Author = "Thomas H. Cormen",
            ISBN = "9780262046305",
            AvailabilityStatus = AvailabilityStatus.Available
        });
    }
}