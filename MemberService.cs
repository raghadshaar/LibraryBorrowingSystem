namespace LibrarySystem;

public class MemberService
{
    private readonly Library _library;

    public MemberService(Library library)
    {
        _library = library;
    }

    public void RegisterMember()
    {
        Console.Write("Enter member ID: ");

        if (!int.TryParse(Console.ReadLine(), out int memberId))
        {
            Console.WriteLine("Member ID must be an integer.");
            return;
        }

        Console.Write("Enter name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter email: ");
        string? email = Console.ReadLine();

        var member = new Member
        {
            Id = memberId,
            Name = name,
            Email = email
        };

        _library.RegisterMember(member);

        Console.WriteLine("Member registered successfully.");
    }
}