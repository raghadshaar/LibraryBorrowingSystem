namespace LibrarySystem
{
    public class Library
    {
        private readonly List<Book> books = new();
        private readonly MemberRepository memberRepository = new();

        public void AddBook(Book book)
        {
            if (book != null && !books.Any(b => b.Id == book.Id))
                books.Add(book);
        }

        public void RemoveBook(int id)
        {
            Book? book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
                books.Remove(book);
        }

        public IReadOnlyList<Book> GetAvailableBooks()
        {
            return books
                .Where(b => b.AvailabilityStatus == AvailabilityStatus.Available)
                .ToList();
        }

        public void RegisterMember(Member member)
        {
            memberRepository.AddMember(member);
        }

        public IReadOnlyList<Member> GetMembers()
        {
            return memberRepository.GetMembers();
        }


        public bool BorrowBook(int memberId, int bookId)
        {
            Member? member = memberRepository
                .GetMembers()
                .FirstOrDefault(m => m.Id == memberId);

            if (member == null)
                return false;

            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
                return false;

            if (book.AvailabilityStatus == AvailabilityStatus.Borrowed)
                return false;

            book.AvailabilityStatus = AvailabilityStatus.Borrowed;

            return true;
        }

        public bool ReturnBook(int memberId, int bookId)
        {
            Member? member = memberRepository
                .GetMembers()
                .FirstOrDefault(m => m.Id == memberId);

            if (member == null)
                return false;

            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
                return false;

            if (book.AvailabilityStatus == AvailabilityStatus.Available)
                return false;

            book.AvailabilityStatus = AvailabilityStatus.Available;

            return true;
        }
    }
}