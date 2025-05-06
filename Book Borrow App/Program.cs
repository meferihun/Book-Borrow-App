using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Borrow_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = FileManager.LoadBooks().Select(info => new Book(info)).ToList();
            List<User> users = FileManager.LoadUsers();

            var menuActions = new Dictionary<string, Action>
            {
                {"                   Library Book Borrow                   ", () => { } },
                { "Manage Books", () => ManageBooks(books) },
                { "Manage Users", () => ManageUsers(users) },
                { "Exit", () => Environment.Exit(0) }
            };

            var print = new Print(menuActions);
            print.PrintMenu();
        }

        private static void ManageBooks(List<Book> books)
        {
            Console.Clear();
            var booksString = books.Select(book => book.Print()).ToList();
            booksString.Insert(0, "Manage Books:");
            var menuActions = booksString.ToDictionary(book => book, act => (Action)(() => { }));

            var print = new Print(menuActions);
            print.PrintMenu();
        }

        private static void ManageUsers(List<User> users)
        {
            Console.Clear();

            var usersString = users.Select(book => book.Print()).ToList();
            usersString.Insert(0, "Manage Users:");
            var menuActions = usersString.ToDictionary(user => user, act => (Action)(() => { }));

            var print = new Print(menuActions);
            print.PrintMenu();
        }
    }
}
