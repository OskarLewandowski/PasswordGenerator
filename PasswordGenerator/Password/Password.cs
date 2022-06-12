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
                Console.WriteLine("Digits included");
            }

            if (passwordComponent.HowManyLargeLetter != 0)
            {
                availableCharacters.AddRange(charactersList.largeLetterList);
                IsAddedHowManyLargeLetter = true;
                Console.WriteLine("Large letter included");
            }

            if (passwordComponent.HowManySmallLetter != 0)
            {
                availableCharacters.AddRange(charactersList.smallLetterList);
                IsAddedHowManySmallLetter = true;
                Console.WriteLine("Small letter included");
            }

            if (passwordComponent.HowManySpecialCharacter != 0)
            {
                availableCharacters.AddRange(charactersList.specialCharactersList);
                IsAddedHowManySpecialCharacter = true;
                Console.WriteLine("Special characters included");
            }

            if (IsAddedHowManyDigits == false &&
                IsAddedHowManyLargeLetter == false &&
                IsAddedHowManySmallLetter == false &&
                IsAddedHowManySpecialCharacter == false)
            {
                Console.WriteLine("Generate default list");
                List<string> defeultList = new List<string>();

                defeultList.AddRange(charactersList.digitsList);
                defeultList.AddRange(charactersList.largeLetterList);
                defeultList.AddRange(charactersList.smallLetterList);
                defeultList.AddRange(charactersList.specialCharactersList);

                return defeultList;
            }

            return availableCharacters;
        }
    }
}
