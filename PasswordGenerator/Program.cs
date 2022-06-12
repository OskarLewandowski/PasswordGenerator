using PasswordGenerator.Password;

PasswordComponent passwordComponents = new PasswordComponent(8, 1, 1, 1, 1);
passwordComponents.Display();
var validatePasswordResult = passwordComponents.ValidatePasswordComponent();

PasswordAvailableCharacters availableCharacters = new PasswordAvailableCharacters();
availableCharacters.Display(availableCharacters.smallLetterList);
availableCharacters.DisplayVerbose(availableCharacters.smallLetterList);

Console.ReadLine();