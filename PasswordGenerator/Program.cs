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
                Terminal.Display();
                break;
            case 4:
                Console.Clear();
                Terminal.Display();
                break;
            case 5:
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

static int? UserInput()
{
    var input = Console.ReadLine();
    if (int.TryParse(input, out int value))
    {
        return value;
    }
    else
    {
        Terminal.WriteLineColor("Bad value", ColorName.DarkRed);
        return null;
    }
}

static int MakeExtendedPassword(PasswordComponent model)
{
    Terminal.WriteLineColor("How much characters in password:", ColorName.Gray);
    var characters = UserInput();
    if (characters == null) { return -1; }
    model.HowManyCharactersInTotal = (int)characters;

    Terminal.WriteLineColor("How many minimum numbers:", ColorName.Gray);
    var digits = UserInput();
    if (digits == null) { return -1; }
    model.HowManyDigits = (int)digits;

    Terminal.WriteLineColor("How many minimum large letters:", ColorName.Gray);
    var largeLetters = UserInput();
    if (largeLetters == null) { return -1; }
    model.HowManyLargeLetter = (int)largeLetters;

    Terminal.WriteLineColor("How many minimum small letters:", ColorName.Gray);
    var smallLetters = UserInput();
    if (smallLetters == null) { return -1; }
    model.HowManySmallLetter = (int)smallLetters;

    Terminal.WriteLineColor("How many minimum special characters:", ColorName.Gray);
    var specialCharacters = UserInput();
    if (specialCharacters == null) { return -1; }
    model.HowManySpecialCharacter = (int)specialCharacters;

    var validatePasswordResult = model.ValidatePasswordComponent();

    if (validatePasswordResult == false)
    {
        Terminal.WriteLineColor("Bad password length", ColorName.DarkRed);
        return -1;
    }

    Password password = new Password();
    var myCharactersList = password.PrepareListOfCharacters(model);

    Terminal.WriteLineColor("How many times to shuffle the list:", ColorName.Gray);
    var shuffle = UserInput();
    if (shuffle == null) { return -1; }
    myCharactersList.Shuffle((int)shuffle);

    password.AddPasswordRequirements(model);

    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);
    Terminal.WriteLineColor(password.GetPassword(myCharactersList), ColorName.Green);
    Terminal.WriteLineColor("-\t-\t-\t-\t-\t-\t-\t", ColorName.DarkMagenta);

    Terminal.WriteLineColor("[ 1 ] Generate a new password ", ColorName.Yellow);
    Terminal.WriteLineColor("[ 2 ] Exit", ColorName.Yellow);
    Terminal.WriteLineColor("What next:", ColorName.Yellow);

    while (true)
    {
        var input = Console.ReadLine();
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