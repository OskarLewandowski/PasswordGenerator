using PasswordGenerator;
using PasswordGenerator.Extensions;
using PasswordGenerator.Password;

PasswordComponent passwordDefaultComponent = new PasswordComponent(12, 2, 2, 2, 2);
string userInput = "";
Terminal.Display();

while (true)
{
    Terminal.WriteLineColor("Type 1 - 5 to choose what you want to do:", ColorName.Yellow);
    userInput = Console.ReadLine().ToLower();

    if (int.TryParse(userInput, out int choice))
    {
        switch (choice)
        {
            case 1:
                Password password = new Password();
                var myCharactersList = password.PrepareListOfCharacters(passwordDefaultComponent);
                myCharactersList.Shuffle(3);
                password.AddPasswordRequirements(passwordDefaultComponent);
                Terminal.WriteLineColor(password.GetPassword(myCharactersList), ColorName.Green);
                break;
            case 2:
                passwordDefaultComponent.Display();
                break;
            case 3:
                Terminal.WriteLineColor("Generate password with extended options", ColorName.Blue);
                break;
            case 4:
                Terminal.WriteLineColor("Edit list - not applied", ColorName.Blue);
                break;
            case 5:
                Console.Clear();
                Terminal.Display();
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Terminal.WriteLineColor("Command not found", ColorName.DarkRed);
                break;
        }
    }
    else
    {
        if (userInput == "exit" || userInput == "quit" || userInput == "q")
        {
            Environment.Exit(0);
        }
        else if (userInput == "help")
        {
            Terminal.WriteLineColor("Program options:", ColorName.Magenta);
            Terminal.Display();
            Terminal.WriteLineColor("Available commands:", ColorName.Magenta);
            Terminal.WriteLineColor("exit, quit, q - close program ", ColorName.DarkYellow);
            Terminal.WriteLineColor("help - information about what we can do ", ColorName.DarkYellow);
        }
        else
        {
            Terminal.WriteLineColor("Command not found", ColorName.DarkRed);
        }
    }
}
