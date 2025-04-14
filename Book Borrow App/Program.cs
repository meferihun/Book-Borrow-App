using Book_Borrow_App;

List<string> options = new()
{
    "Profile",
    "Borrowed Books",
    "Exit"
};
Print print = new(options);


while (true) 
{
    print.PrintMenu();
}
