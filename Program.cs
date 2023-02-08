using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{
    // Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public string Pages { get; set; }

    // Constructor
    public Book(string title, string author, string pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }

    // Method to return a string
    public override string ToString()
    {
        return "Title: " + Title + ", Author: " + Author + ", Pages: " + Pages;
    }
}

class Program
{
    // --------------------------------------------------------------------------------------------------------------
    // Main method
    public static void Main()
    {
        // Create a new instance of the Librarian class
        Librarian libr = new Librarian();

        bool running = true;

        while (running)
        {
            // Prompt user for menu option
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tEnter a menu option\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t1. Add a book to the library");
            Console.WriteLine("\t2. List books in the library");
            Console.WriteLine("\t3. Search for a book in the library");
            Console.WriteLine("\t4. Exit");

            // Read the user input
            if(Int32.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        // Clear the console
                        Console.Clear();

                        // Ask the user to enter a book
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter a book to add to the library");

                        // Read the user input
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter the title of the book:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string title = Console.ReadLine();
                        
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter the author of the book:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string author= Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter the number of pages in the book:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string pages = Console.ReadLine();

                        // Create a new instance of the Book class
                        Book book = new Book(title, author, pages);

                        // Call the NewBook method
                        libr.NewBook(book);

                        break;

                    case 2:
                        // Clear the console
                        Console.Clear();

                        // Call the ListBooks method
                        libr.ListBooks();

                        break;

                    case 3:
                        // Clear the Console
                        Console.Clear();

                        // Call the SearchBook Method
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter a book to search for in the library");
                        string search = Console.ReadLine();

                        libr.SearchBook(search);

                        break;

                    case 4:
                        running = false;

                        break;
                }
            }
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Librarian class
    private class Librarian
    {
        // Create a list of books
        private List<Book> BookList = new List<Book>();

        // Create a new instance of the Library class
        Library lib = new Library();

        // Method to add a new book to the library
        public void NewBook(Book book)
        {
            lib.AddBook(BookList, book);
        }

        // Method to list books in the library
        public void ListBooks()
        {
            lib.ListBooks(BookList);
        }

        // Method to search for a book in the library
        public void SearchBook(string title)
        {
            lib.SearchBook(BookList, title);
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Library class
    private class Library
    {
        // Method to add a new book to the library
        public void AddBook(List<Book> BookList, Book book)
        {
            BookList.Add(book);
            
            // Clear the console
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Added " + book + " to the library");
        }

        // Method to list books in the library
        public void ListBooks(List<Book> BookList)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Listed books in the library");

            foreach (Book book in BookList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(book.ToString());
            }
        }

        // Method to search for a book in the Library
        public void SearchBook(List<Book> BookList, string title)
        {
            foreach (Book book in BookList)
            {
                if (book.Title == title)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(book.ToString());
                }
            }
        }
    }
}
