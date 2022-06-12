using PasswordGenerator.Password;

PasswordComponent passwordComponents = new PasswordComponent(8, 1, 1, 1, 1);
Console.WriteLine(
    $"CharactersInTotal: {passwordComponents.HowManyCharactersInTotal}\n" +
    $"Digits: {passwordComponents.HowManyDigits}\n" +
    $"LargeLetter: {passwordComponents.HowManyLargeLetter}\n" +
    $"SmallLetter: {passwordComponents.HowManySmallLetter}\n" +
    $"SpecialCharacter: {passwordComponents.HowManySpecialCharacter}\n");

Console.ReadLine();