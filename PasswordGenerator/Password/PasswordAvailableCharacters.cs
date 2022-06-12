using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Password
{
    public class PasswordAvailableCharacters
    {
        public List<string> digitsList = new List<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        public List<string> largeLetterList = new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        };

        public List<string> smallLetterList = new List<string>
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
        };

        public List<string> specialCharactersList = new List<string>
        {
            "~", "!", "?", "@", "#", "$", "%", "^", "&", "*", "_", "-", "+", "(", ")",
            "[", "]", "{", "}", "|", "^", "&", ">", "<", "/", "\\", "\"", "'", ".",
            ",", ":", ";", "="
        };

        public void Display(List<string> list)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        public void DisplayVerbose(List<string> list)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"ID:[ {i} ] Value:[ {list[i]} ]");
            }

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }
    }
}
