using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class Terminal
    {
        public static void Display()
        {
            Terminal.WriteLineColor("[ 1 ] Generate password with default options", ColorName.Blue);
            Terminal.WriteLineColor("[ 2 ] Generate password with extended options", ColorName.Blue);
            Terminal.WriteLineColor("[ 3 ] Edit list - not applied", ColorName.Blue);
            Terminal.WriteLineColor("[ 4 ] Clear", ColorName.Blue);
            Terminal.WriteLineColor("[ 5 ] Exit", ColorName.Blue);
        }

        public static void WriteLineColor(string message, ColorName colorName)
        {
            switch (colorName)
            {
                case ColorName.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                    break;
                case ColorName.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkBlue:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkGreen:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkCyan:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkRed:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkMagenta:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkYellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(message);
                    break;
                case ColorName.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(message);
                    break;
                case ColorName.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(message);
                    break;
                case ColorName.DarkGray:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(message);
                    break;
                case ColorName.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message);
                    break;
                case ColorName.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    break;
                case ColorName.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message);
                    break;
                case ColorName.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(message);
                    break;
                case ColorName.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message);
                    break;
                default:
                    Console.WriteLine("Available colors:");
                    foreach (var color in Enum.GetNames(typeof(ColorName)))
                    {
                        Console.WriteLine(color);
                    }
                    break;
            }
        }
    }
}
