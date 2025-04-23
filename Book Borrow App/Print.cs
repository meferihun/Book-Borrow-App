using System;
using System.Collections.Generic;

namespace Book_Borrow_App
{
    internal class Print
    {
        private readonly Dictionary<string, Action> _menuActions;

        public int CurrentIndex { get; private set; }

        public Print(Dictionary<string, Action> menuActions)
        {
            _menuActions = menuActions;
            CurrentIndex = 0;
        }

        public void PrintMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                HandleInput();
            }
        }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    CurrentIndex = (CurrentIndex - 1 + _menuActions.Count) % _menuActions.Count;
                    break;

                case ConsoleKey.DownArrow:
                    CurrentIndex = (CurrentIndex + 1 + _menuActions.Count) % _menuActions.Count;
                    break;

                case ConsoleKey.Enter:
                    var selectedOption = _menuActions.ElementAt(CurrentIndex).Key;
                    var manageOption = new ManageOption(_menuActions);
                    manageOption.Manage(selectedOption);
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

            foreach (var option in _menuActions.Keys)
            {
                if (option == _menuActions.ElementAt(CurrentIndex).Key)
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
