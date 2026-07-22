using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public abstract class Book
    {

        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }
        public abstract int BorrowingDays { get; }

    }

    public enum AvailabilityStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost,
        UnderMaintenance
    }
    public class PhysicalBook : Book
    {
        public override int BorrowingDays => 14;
    }

    public class EBook : Book
    {
        public override int BorrowingDays => 7;
    }
}