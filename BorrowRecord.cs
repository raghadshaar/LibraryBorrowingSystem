using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   namespace LibrarySystem
    {
        public class BorrowRecord
        {
            public Member Member { get; set; }
            public Book Book { get; set; }
            public DateTime BorrowDate { get; set; }
            public DateTime DueDate { get; set; }
            public bool IsReturned { get; set; }
        }
    }
}
