using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Spectre.Console;

public class Book
{
    // Properties
    public string Type { get; set; }
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

namespace Library
{
    internal class Program
    {
        // --------------------------------------------------------------------------------------------------------------
        // Main method
        // --------------------------------------------------------------------------------------------------------------
        static void Main()
        {
            // Create a new instance of the Librarian class
            Librarian libr = new Librarian();

            bool running = true;

            while (running)
            {
                // Prompt user for menu option
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n * * * * * * * * * * * * * * * * *"
                    +             "\n *      Enter a menu option      *"
                    +             "\n * * * * * * * * * * * * * * * * *\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  1. Add to the library");
                Console.WriteLine("  2. List items in the library");
                Console.WriteLine("  3. Search the library");
                Console.WriteLine("  4. Exit");

                // Read the user input
                if(Int32.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            // Clear the Console
                            Console.Clear();

                            var bookType = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Add to the library")
                                    .PageSize(10)
                                    .AddChoices(new[] {"Novel", "Short Story", "Magazine"})
                                );

                            switch (bookType)
                            {
                                case "Novel":
                                    // Add Novel 
                                    Novel novel = new Novel(GetTitle(), GetAuthor(), GetPages());
                                    libr.NewBook(novel);

                                    break;
                                case "Short Story":
                                    // Add Short 
                                    Short shorty = new Short(GetTitle(), GetAuthor(), GetPages());
                                    libr.NewBook(shorty);

                                    break;
                                case "Magazine":
                                    // Add Magazine
                                    Magazine magazine = new Magazine(GetTitle(), GetAuthor(), GetPages());
                                    libr.NewBook(magazine);

                                    break;
                            }
                            break;

                        case 2:
                            // Clear the console
                            Console.Clear();

                            // Call the ListBooks method
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            libr.ListBooks();
                            Console.ResetColor();

                            break;

                        case 3:
                            // Clear the Console
                            Console.Clear();

                            // Call the SearchBook Method
                            Console.WriteLine("Search for a title in the library");
                            
                            Console.ForegroundColor = ConsoleColor.Blue;
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

        public static string GetTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the title of the book:");
            Console.ForegroundColor = ConsoleColor.Blue;
            return Console.ReadLine();
        }

        public static string GetAuthor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the author of the book:");
            Console.ForegroundColor = ConsoleColor.Blue;
            return Console.ReadLine();
        }

        public static string GetPages()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the number of pages in the book:");
            Console.ForegroundColor = ConsoleColor.Blue;
            return Console.ReadLine();
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Librarian class
    // --------------------------------------------------------------------------------------------------------------
    public class Librarian
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
    // --------------------------------------------------------------------------------------------------------------
    public class Library
    {
        // Method to add a new book to the library
        public void AddBook(List<Book> BookList, Book book)
        {
            BookList.Add(book);
            
            // Clear the console
            Console.Clear();

            Console.WriteLine("Added to the library:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var each in book.ToString().Split(", "))
            {
                Console.WriteLine(each);
            }
        }

        // Method to list books in the library
        public void ListBooks(List<Book> BookList)
        {
            // Create a table, add the books to it and write it to the console
            var table = new ConsoleTable("Title", "Author", "Pages", "Type");
            foreach (Book book in BookList)
            {
                table.AddRow(book.Title, book.Author, book.Pages, book.Type);
            }
            table.Write(Format.Minimal);
        }

        // Method to search for a book in the Library
        public void SearchBook(List<Book> BookList, string title)
        {
            foreach (Book book in BookList)
            {
                if (book.Title == title)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var each in book.ToString().Split(", "))
                    {
                        Console.WriteLine(each);
                    }
                }
            }
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Magazine class
    // --------------------------------------------------------------------------------------------------------------
    public class Magazine : Book
    {
        // Constructor
        public Magazine(string title, string author, string pages) : base(title, author, pages)
        {
            Type = "Magazine";
        }

        // Method to return a string
        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author + ", Pages: " + Pages + ", Type: " + Type;
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Short class
    // --------------------------------------------------------------------------------------------------------------
    public class Short : Book 
    {
        // Constructor
        public Short(string title, string author, string pages) : base(title, author, pages)
        {
            Type = "Short";
        }

        // Method to return a string
        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author + ", Pages: " + Pages + ", Type: " + Type;
        }
    }

    // --------------------------------------------------------------------------------------------------------------
    // Novel class
    // --------------------------------------------------------------------------------------------------------------
    public class Novel : Book
    {
        // Constructor
        public Novel(string title, string author, string pages) : base(title, author, pages)
        {
            Type = "Novel";
        }

        // Method to return a string
        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author + ", Pages: " + Pages + ", Type: " + Type;
        }
    }

    // public class IntegrationTests
    // {
    //     [fact]
    //     public void AddBook()
    //     {
    //         // Arrange
    //         var book = new Book("The Hobbit", "J.R.R. Tolkien", "310");
    //         var librarian = new Librarian();

    //         // Act
    //         librarian.NewBook(book);

    //         // Assert
    //         Assert.Equal(1, librarian.BookList.Count);
    //     }
    // }
}
