using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {


            if (book != null && !books.Any(b => b.Id == book.Id))
                books.Add(book);


        }

        public void RemoveBook(int id)
        {
            Book? book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return books
                .Where(b => b.AvailabilityStatus == AvailabilityStatus.Available)
                .ToList();
        }

    }
}

