using PasswordGenerator.Password;

PasswordComponent passwordComponents = new PasswordComponent(8, 1, 1, 1, 1);
passwordComponents.Display();
var validatePasswordResult = passwordComponents.ValidatePasswordComponent();

PasswordAvailableCharacters availableCharacters = new PasswordAvailableCharacters();

Console.ReadLine();