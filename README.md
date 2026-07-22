# Library Borrowing System

A C# Console Application that simulates a simple library borrowing system. The application allows users to manage books and members, borrow and return books, and search the library catalog.

---

## Features

### Book Management

- Add Physical Books
- Add EBooks
- View Available Books
- Search Books by:
  - Title
  - Author
  - ISBN

### Member Management

Each member contains:

- Id
- Name
- Email

The application allows registering new members.

### Borrowing and Returning

The system supports:

- Borrowing a book only if it is available
- Preventing borrowing unavailable books
- Returning borrowed books
- Updating the availability status automatically
- Recording borrowing history

### Borrowing Rules

| Book Type | Borrowing Period |
| ---------- | ---------------- |
| Physical Book | 14 Days |
| EBook | 7 Days |

---

## Console Menu

```text
1 - Add Physical Book
2 - Add EBook
3 - Register Member
4 - Borrow Book
5 - Return Book
6 - View Available Books
7 - View Borrow Records
8 - Search Books
9 - Exit
```

The application continues running until the user chooses to exit.

---

## Project Structure

```text
LibrarySystem/
│
├── Services/
│   ├── BookService.cs
│   ├── BorrowingService.cs
│   ├── ConsolePrinter.cs
│   ├── LibrarySeeder.cs
│   └── MemberService.cs
│
├── Book.cs
├── BorrowRecord.cs
├── Library.cs
├── Member.cs
├── MemberRepository.cs
├── Program.cs
├── .gitignore
└── README.md
```

---

## Code Organization

The project separates related responsibilities into service classes:

- `BookService` handles adding, displaying, and searching for books.
- `MemberService` handles member registration.
- `BorrowingService` handles borrowing, returning, and viewing borrowing records.
- `ConsolePrinter` handles formatted console output.
- `LibrarySeeder` adds the initial sample books.
- `Library` contains the main library business logic.
- `Program` creates the required objects, displays the menu, and directs each option to the appropriate service.

## Technologies Used

- C#
- .NET
- Console Application
- Object-Oriented Programming (OOP)
- LINQ
- Git
- GitHub

---

## How to Run

1. Clone the repository.

```bash
git clone <repository-url>
```

2. Open the project in Visual Studio.

3. Build the solution.

4. Run the application.

5. Use the console menu to interact with the system.

---

## Implemented Features

- Book Management
- Member Management
- Borrowing and Returning
- Search by Title
- Search by Author
- Search by ISBN
- Borrow Records
- Availability Management

---

## Git Workflow

Each feature was implemented in a separate Git branch before being merged into the main branch.

---
