using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Borrow_App
{
    internal class Print
    {
        private readonly List<string> _options;

        public int CurrentIndex { get; private set; }

        public Print(List<string> options)
        {
            _options = options;
            CurrentIndex = 0;
        }

       public void PrintMenu()
       {
            Console.Clear();
            DisplayMenu();
            HandleInput();
       }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    CurrentIndex = (CurrentIndex - 1 + _options.Count) % _options.Count;
                    break;

                case ConsoleKey.DownArrow:
                    CurrentIndex = (CurrentIndex + 1 + _options.Count) % _options.Count;
                    break;

                case ConsoleKey.Enter:
                    Environment.Exit(0);
                    break;

                default:
                    CurrentIndex = 0;
                    break;
            }
        }

        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                   Library Book Borrow                   ");
            Console.ResetColor();

            foreach (var option in _options)
            {
                if (option == _options[CurrentIndex])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"---> {option} <---");
                    Console.ResetColor();
                }
                else 
                    Console.WriteLine($"     {option}     ");
            }
        }
    }
}
