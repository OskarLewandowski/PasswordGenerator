﻿using PasswordGenerator.Extensions;
using PasswordGenerator.Password;

PasswordComponent passwordComponents = new PasswordComponent(8, 1, 0, 1, 1);
passwordComponents.Display();
var validatePasswordResult = passwordComponents.ValidatePasswordComponent();

PasswordAvailableCharacters availableCharacters = new PasswordAvailableCharacters();
Console.WriteLine();
//availableCharacters.Display(availableCharacters.smallLetterList);
//availableCharacters.DisplayVerbose(availableCharacters.smallLetterList);

Password password = new Password();
var myCharactersList = password.PrepareListOfCharacters(passwordComponents);

myCharactersList.Shuffle(3);

Console.ReadLine();