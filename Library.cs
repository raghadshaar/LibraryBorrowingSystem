namespace LibrarySystem
{
    public class Library
    {
        private readonly List<Book> books = new();
        private readonly MemberRepository memberRepository = new();
        private readonly List<BorrowRecord> borrowRecords = new();

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
            Member? member = memberRepository.GetMembers()
                .FirstOrDefault(m => m.Id == memberId);

            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (member == null || book == null)
                return false;

            if (book.AvailabilityStatus != AvailabilityStatus.Available)
                return false;

            book.AvailabilityStatus = AvailabilityStatus.Borrowed;

            BorrowRecord record = new BorrowRecord
            {
                Member = member,
                Book = book,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(book.BorrowingDays),
                IsReturned = false
            };

            borrowRecords.Add(record);

            return true;
        }

        public bool ReturnBook(int memberId, int bookId)
        {
            BorrowRecord? record = borrowRecords.FirstOrDefault(r =>
                r.Member.Id == memberId &&
                r.Book.Id == bookId &&
                !r.IsReturned);

            if (record == null)
                return false;

            record.IsReturned = true;
            record.Book.AvailabilityStatus = AvailabilityStatus.Available;

            return true;
        }

        public IReadOnlyList<BorrowRecord> GetBorrowRecords()
        {
            return borrowRecords;
        }

      
        public List<Book> SearchByTitle(string title)
        {
            return books
                .Where(b => b.Title != null &&
                            b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<Book> SearchByAuthor(string author)
        {
            return books
                .Where(b => b.Author != null &&
                            b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public Book? SearchByISBN(string isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }
       

    }
}