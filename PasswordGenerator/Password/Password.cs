using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Password
{
    public class Password
    {
        private PasswordAvailableCharacters charactersList = new PasswordAvailableCharacters();
        private Dictionary<string, int> passwordRequirements = new Dictionary<string, int>();

        public List<string> PrepareListOfCharacters(PasswordComponent passwordComponent)
        {
            List<string> availableCharacters = new List<string>();

            bool IsAddedHowManyDigits = false;
            bool IsAddedHowManyLargeLetter = false;
            bool IsAddedHowManySmallLetter = false;
            bool IsAddedHowManySpecialCharacter = false;

            if (passwordComponent.HowManyDigits != 0)
            {
                availableCharacters.AddRange(charactersList.digitsList);
                IsAddedHowManyDigits = true;
                //Console.WriteLine("Digits included");
            }

            if (passwordComponent.HowManyLargeLetter != 0)
            {
                availableCharacters.AddRange(charactersList.largeLetterList);
                IsAddedHowManyLargeLetter = true;
                //Console.WriteLine("Large letter included");
            }

            if (passwordComponent.HowManySmallLetter != 0)
            {
                availableCharacters.AddRange(charactersList.smallLetterList);
                IsAddedHowManySmallLetter = true;
                //Console.WriteLine("Small letter included");
            }

            if (passwordComponent.HowManySpecialCharacter != 0)
            {
                availableCharacters.AddRange(charactersList.specialCharactersList);
                IsAddedHowManySpecialCharacter = true;
                //Console.WriteLine("Special characters included");
            }

            if (IsAddedHowManyDigits == false &&
                IsAddedHowManyLargeLetter == false &&
                IsAddedHowManySmallLetter == false &&
                IsAddedHowManySpecialCharacter == false)
            {
                //Console.WriteLine("Generate default list");
                List<string> defeultList = new List<string>();

                defeultList.AddRange(charactersList.digitsList);
                defeultList.AddRange(charactersList.largeLetterList);
                defeultList.AddRange(charactersList.smallLetterList);
                defeultList.AddRange(charactersList.specialCharactersList);

                return defeultList;
            }

            return availableCharacters;
        }

        public Dictionary<string, int> AddPasswordRequirements(PasswordComponent passwordComponent)
        {
            Type objType = passwordComponent.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(passwordComponent);
                //Console.WriteLine($"{propName} - {propValue}");

                if (propValue != null && (int)propValue != 0)
                {
                    passwordRequirements.Add(propName, (int)propValue);
                }
            }

            return passwordRequirements;
        }

        public string GeneratePassword(List<string> characterList)
        {
            var result = passwordRequirements.TryGetValue("HowManyCharactersInTotal", out int lenght);

            if (result == false)
            {
                return "Something went wrong";
            }

            string password = "";
            Random random = new Random();

            while (password.Length != lenght)
            {
                int index = random.Next(characterList.Count);
                password += characterList[index];
            }

            return password.ToString();
        }

        public bool CheckPassword(string password)
        {
            var requirements = passwordRequirements;

            int charactersInTotal = 0;
            int digits = 0;
            int upperCase = 0;
            int lowerCase = 0;
            int specialCase = 0;

            foreach (var sign in password)
            {
                if (char.IsDigit(sign))
                {
                    digits++;
                }
                else if (char.IsUpper(sign))
                {
                    upperCase++;
                }
                else if (char.IsLower(sign))
                {
                    lowerCase++;
                }
                else if (charactersList.specialCharactersList.Contains(sign.ToString()))
                {
                    specialCase++;
                }
                charactersInTotal++;
            }

            //Console.WriteLine("Password specific:");
            //Console.WriteLine("Digits: " + digits);
            //Console.WriteLine("LargeLetter: " + upperCase);
            //Console.WriteLine("SmallLetter: " + lowerCase);
            //Console.WriteLine("SpecialCharacter: " + specialCase);
            //Console.WriteLine("CharactersInTotal: " + charactersInTotal);

            foreach (var requirement in requirements)
            {
                var key = requirement.Key;
                var value = requirement.Value;

                if (key == "HowManyCharactersInTotal")
                {
                    var passwordLenght = password.Length;

                    if (!(passwordLenght == value))
                    {
                        return false;
                    }
                }
                else if (key == "HowManyDigits")
                {
                    if (!(digits >= value))
                    {
                        return false;
                    }
                }
                else if (key == "HowManyLargeLetter")
                {
                    if (!(upperCase >= value))
                    {
                        return false;
                    }
                }
                else if (key == "HowManySmallLetter")
                {
                    if (!(lowerCase >= value))
                    {
                        return false;
                    }
                }
                else if (key == "HowManySpecialCharacter")
                {
                    if (!(specialCase >= value))
                    {
                        return false;
                    }
                }
            }

            //Console.WriteLine("Your password is: good");
            return true;
        }

        public string GetPassword(List<string> characterList)
        {
            var generatedPassword = GeneratePassword(characterList);
            var resultCheckPassword = CheckPassword(generatedPassword);

            if (resultCheckPassword == true)
            {
                return generatedPassword;
            }
            else
            {
                while (resultCheckPassword == false)
                {
                    generatedPassword = GeneratePassword(characterList);
                    resultCheckPassword = CheckPassword(generatedPassword);
                }

                return generatedPassword;
            }
        }
    }
}
