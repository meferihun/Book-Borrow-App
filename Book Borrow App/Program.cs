using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Manage Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"(ID: {book.Info.Id}) - {book.Info.Title} - Author: {book.Info.Author}");
            }
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        private static void ManageUsers(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("Manage Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.Name} (ID: {user.Id})");
            }
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
