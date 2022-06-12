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
    }
}
