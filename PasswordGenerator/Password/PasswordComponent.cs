using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Password
{
    public class PasswordComponent
    {
        public int HowManyCharactersInTotal { get; set; }
        public int HowManyDigits { get; set; }
        public int HowManyLargeLetter { get; set; }
        public int HowManySmallLetter { get; set; }
        public int HowManySpecialCharacter { get; set; }

        public PasswordComponent(int howManyCharactersInTotal, int howManyDigits, int howManyLargeLetter,
            int howManySmallLetter, int howManySpecialCharacter)
        {
            HowManyCharactersInTotal = howManyCharactersInTotal;
            HowManyDigits = howManyDigits;
            HowManyLargeLetter = howManyLargeLetter;
            HowManySmallLetter = howManySmallLetter;
            HowManySpecialCharacter = howManySpecialCharacter;
        }

        public bool ValidatePasswordComponent()
        {
            var totalCharacters = HowManyCharactersInTotal;

            var sumOfCharacters = HowManyDigits
                + HowManyLargeLetter
                + HowManySmallLetter
                + HowManySpecialCharacter;

            if (totalCharacters >= sumOfCharacters)
            {
                Console.WriteLine("Validation successful");
                return true;
            }

            Console.WriteLine("Validation failed");
            return false;
        }

        public void Display()
        {
            Console.WriteLine($"HowManyCharactersInTotal: {HowManyCharactersInTotal}\n" +
                $"HowManyDigits: {HowManyDigits}\n" +
                $"HowManyLargeLetter: {HowManyLargeLetter}\n" +
                $"HowManySmallLetter: {HowManySmallLetter}\n" +
                $"HowManySpecialCharacter: {HowManySpecialCharacter}\n");
        }
    }
}
