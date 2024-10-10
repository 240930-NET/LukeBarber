using System;
using System.Text.RegularExpressions;

namespace StudentPhonebook
{
    public static class Validation
    {
        // Validate ID: non-empty string
        public static bool IsValidId(string input)
        {
            return Regex.IsMatch(input, @"^[A-Za-z]{3}\d{6}$");
        }

        // Validate Name: non-empty string
        public static bool IsValidName(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validate Phone Number: exactly 10 digits
        public static bool IsValidPhoneNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d{10}$");
        }

        // Get valid input with a custom validator function
        public static string GetValidInput(string prompt, Func<string, bool> validate)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!validate(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!validate(input));
            
            return input;
        }
    }
}
