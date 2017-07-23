using System;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;
using Microsoft.Extensions.Logging;

namespace Ondo.Logging.ConsoleApp
{
    internal class GUI
    {
        private readonly LoggingExamples _loggingExamples;
        internal GUI(LoggingExamples loggingExamples)
        {
           _loggingExamples = loggingExamples;
        }

        internal void UserInterface()
        {
            Console.WriteAscii("Logging Example", Color.Orange);
            StyleSheet styleSheet = new StyleSheet(Color.White);
            styleSheet.AddStyle("q", Color.OrangeRed);
            Console.WriteLineStyled("Write q to quit", styleSheet);
            System.Console.WriteLine(Environment.NewLine);
            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter input:");
                Console.WriteLine($"{LogLevel.Trace.ToString("D")} - Trace");
                Console.WriteLine($"{LogLevel.Debug.ToString("D")} - Debug");
                Console.WriteLine($"{LogLevel.Information.ToString("D")} - Information");
                Console.WriteLine($"{LogLevel.Warning.ToString("D")} - Warning");
                Console.WriteLine($"{LogLevel.Error.ToString("D")} - Error");
                Console.WriteLine($"{LogLevel.Critical.ToString("D")} - Critical");

                string line = Console.ReadLine();
                if (line == "q")
                {
                    break;
                }

                _loggingExamples.ShowLogExamples(line);

                System.Console.WriteLine(Environment.NewLine);
                Console.WriteLineStyled("Write q to quit", styleSheet);
                System.Console.WriteLine(Environment.NewLine);
            }
        }       
    }
}
