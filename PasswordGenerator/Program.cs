using PasswordGenerator.Extensions;
using PasswordGenerator.Password;

PasswordComponent passwordComponents = new PasswordComponent(12, 6, 3, 1, 0);
passwordComponents.Display();
var validatePasswordResult = passwordComponents.ValidatePasswordComponent();

PasswordAvailableCharacters availableCharacters = new PasswordAvailableCharacters();
Console.WriteLine();
//availableCharacters.Display(availableCharacters.smallLetterList);
//availableCharacters.DisplayVerbose(availableCharacters.smallLetterList);

Password password = new Password();
var myCharactersList = password.PrepareListOfCharacters(passwordComponents);

myCharactersList.Shuffle(3);

Console.WriteLine("\nPassword requirements");
password.AddPasswordRequirements(passwordComponents);

Console.WriteLine("Generate password");
var myGeneratedPassword = password.GeneratePassword(myCharactersList);
Console.WriteLine($"myGeneratedPassword: {myGeneratedPassword}");
Console.WriteLine("\nCheckPassword");
var result = password.CheckPassword(myGeneratedPassword);
Console.WriteLine($"PasswordCheck: {result}");

var pass1 = password.GetPassword(myCharactersList);
Console.WriteLine("My password:");
Console.WriteLine(pass1);
Console.ReadLine();