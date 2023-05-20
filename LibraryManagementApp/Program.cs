using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

// Class representing the book
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
    }
}

// Class representing the library
class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Library Books:");
        foreach (Book book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} ({(book.IsAvailable ? "Available" : "Not Available")})");
        }
    }

    public Book FindBookByTitle(string title)
    {
        return books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void BorrowBook(Book book)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            Console.WriteLine("Book borrowed successfully!");
        }
        else
        {
            Console.WriteLine("Book is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (!book.IsAvailable)
        {
            book.IsAvailable = true;
            Console.WriteLine("Book returned successfully!");
        }
        else
        {
            Console.WriteLine("Book is already available.");
        }
    }
}

// Main class of the program
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // 10 default books in library
        library.AddBook(new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling"));
        library.AddBook(new Book("The Hobbit", "J.R.R. Tolkien"));
        library.AddBook(new Book("A Game of Thrones", "George R.R. Martin"));
        library.AddBook(new Book("The Name of the Wind", "Patrick Rothfuss"));
        library.AddBook(new Book("Carrie", "Stephen King"));
        library.AddBook(new Book("Sapiens: A Brief History of Humankind", "Juwal Noach Harari"));
        library.AddBook(new Book("Atomic Habits", "James Clear"));
        library.AddBook(new Book("Where the Crawdads Sing", "Delia Owens"));
        library.AddBook(new Book("Lifespan: Why We Age", "David Sinclair"));
        library.AddBook(new Book("Crime and Punishment", "Fiodor Dostojewski"));

        while (true)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Display books");
            Console.WriteLine("4. Borrow a book");
            Console.WriteLine("5. Return a book");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter title of the book: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author of the book: ");
                    string author = Console.ReadLine();
                    library.AddBook(new Book(title, author));
                    Console.WriteLine("Book added successfully!");
                    break;
                case "2":
                    Console.Write("Enter title of the book to remove: ");
                    string removeTitle = Console.ReadLine();
                    Book removeBook = library.FindBookByTitle(removeTitle);
                    if (removeBook != null)
                    {
                        library.RemoveBook(removeBook);
                        Console.WriteLine("Book removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found in the library.");
                    }
                    break;
                case "3":
                    library.DisplayBooks();
                    break;
                case "4":
                    Console.Write("Enter title of the book to borrow: ");
                    string borrowTitle = Console.ReadLine();
                    Book borrowBook = library.FindBookByTitle(borrowTitle);
                    if (borrowBook != null)
                    {
                        library.BorrowBook(borrowBook);
                    }
                    else
                    {
                        Console.WriteLine("Book not found in the library.");
                    }
                    break;
                case "5":
                    Console.Write("Enter title of the book to return: ");
                    string returnTitle = Console.ReadLine();
                    Book returnBook = library.FindBookByTitle(returnTitle);
                    if (returnBook != null)
                    {
                        library.ReturnBook(returnBook);
                    }
                    else
                    {
                        Console.WriteLine("Book not found in the library.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
