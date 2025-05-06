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
            CurrentIndex = 1;
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
                    CurrentIndex = CurrentIndex - 1 > 0 ? CurrentIndex - 1 : CurrentIndex;
                    break;

                case ConsoleKey.DownArrow:
                    CurrentIndex = CurrentIndex + 1 < _menuActions.Count ? CurrentIndex + 1 : CurrentIndex;
                    break;

                case ConsoleKey.Enter:
                    var selectedOption = _menuActions.ElementAt(CurrentIndex).Key;
                    var manageOption = new ManageOption(_menuActions);
                    manageOption.Manage(selectedOption);
                    break;

                default:
                    CurrentIndex = 1;
                    break;
            }
        }

        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var title = _menuActions.Keys.ElementAt(0);
            Console.WriteLine(title);
            Console.ResetColor();

            foreach (var option in _menuActions.Keys.Skip(0))
            {
                if (option != title)
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
}
