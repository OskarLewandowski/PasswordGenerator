using PasswordGenerator;
using PasswordGenerator.Extensions;
using PasswordGenerator.Password;

PasswordComponent passwordDefaultComponent = new PasswordComponent(12, 2, 2, 2, 2);
PasswordComponent passwordExtendedComponent = new PasswordComponent(0, 0, 0, 0, 0);

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
                Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
                Terminal.WriteLineColor(password.GetPassword(myCharactersList), ColorName.Green);
                Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
                break;
            case 2:
                passwordDefaultComponent.Display();
                break;
            case 3:
                MakeExtendedPassword(passwordExtendedComponent);
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



static int MakeExtendedPassword(PasswordComponent model)
{
    Terminal.WriteLineColor("How much characters in password:", ColorName.Gray);
    var input = Console.ReadLine();
    if (int.TryParse(input, out int characters))
    {
        model.HowManyCharactersInTotal = characters;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    Terminal.WriteLineColor("How many minimum numbers:", ColorName.Gray);
    input = Console.ReadLine();
    if (int.TryParse(input, out int digits))
    {
        model.HowManyDigits = digits;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    Terminal.WriteLineColor("How many minimum large letters:", ColorName.Gray);
    input = Console.ReadLine();
    if (int.TryParse(input, out int largeLetters))
    {
        model.HowManyLargeLetter = largeLetters;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    Terminal.WriteLineColor("How many minimum small letters:", ColorName.Gray);
    input = Console.ReadLine();
    if (int.TryParse(input, out int smallLetters))
    {
        model.HowManySmallLetter = smallLetters;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    Terminal.WriteLineColor("How many minimum special characters:", ColorName.Gray);
    input = Console.ReadLine();
    if (int.TryParse(input, out int specialCharacters))
    {
        model.HowManySpecialCharacter = specialCharacters;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    Password password = new Password();
    var myCharactersList = password.PrepareListOfCharacters(model);

    Terminal.WriteLineColor("How many times to shuffle the list:", ColorName.Gray);
    input = Console.ReadLine();
    if (int.TryParse(input, out int shuffle))
    {
        myCharactersList.Shuffle(shuffle);
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
    }

    password.AddPasswordRequirements(model);

    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
    Terminal.WriteLineColor(password.GetPassword(myCharactersList), ColorName.Green);
    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);

    Terminal.WriteLineColor("[ 1 ] Generate a new password ", ColorName.Yellow);
    Terminal.WriteLineColor("[ 2 ] Exit", ColorName.Yellow);
    Terminal.WriteLineColor("What next:", ColorName.Yellow);

    while (true)
    {
        input = Console.ReadLine();
        if (int.TryParse(input, out int choice))
        {
            switch (choice)
            {
                case 1:
                    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
                    Terminal.WriteLineColor(password.GetPassword(myCharactersList), ColorName.Green);
                    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
                    break;
                case 2:
                    return 0;
                default:
                    break;
            }
        }
        else
        {
            Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
        }
    }
}