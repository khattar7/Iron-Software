using System;
using System.Collections.Generic;
using System.Text;

public class OldPhone
{   // Converts multi-tap numeric input (e.g., "4433555 555666#") to text		
    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || input[input.Length - 1] != '#')
            throw new ArgumentException("Input must end with '#'");

        Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            { '1', "&’(" },         // Updated mapping for '1'
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        StringBuilder result = new StringBuilder();
        List<char> buffer = new List<char>();

        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];

            if (current == '#')
            {
                break;
            }
            else if (current == '*')
            {   // Backspace: apply buffer first then remove last character
                AppendBufferedCharacter(buffer, keypad, result);
                buffer.Clear();

                if (result.Length > 0)
                    result.Remove(result.Length - 1, 1);
            }
            else if (current == ' ')
            {
                AppendBufferedCharacter(buffer, keypad, result);
                buffer.Clear();
            }
            else if (char.IsDigit(current))
            {
                if (buffer.Count > 0 && buffer[0] != current)
                {
                    AppendBufferedCharacter(buffer, keypad, result);
                    buffer.Clear();
                }
                buffer.Add(current);
            }
        }

        AppendBufferedCharacter(buffer, keypad, result);
        return result.ToString();
    }

    private static void AppendBufferedCharacter(List<char> buffer, Dictionary<char, string> keypad, StringBuilder result)
    {
        if (buffer.Count == 0) return;

        char key = buffer[0];
        int pressCount = buffer.Count;

        if (keypad.ContainsKey(key) && keypad[key].Length > 0)
        {
            string letters = keypad[key];
            int index = (pressCount - 1) % letters.Length;
            result.Append(letters[index]);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the old phone pad input (digits, *, space, must end with '#'):");

        string userInput = Console.ReadLine();

        while (!IsValidInput(userInput))
        {
            Console.WriteLine("Invalid input. Please enter only digits, '*', spaces, and ensure it ends with '#':");
            userInput = Console.ReadLine();
        }

        try
        {
            string output = OldPhone.OldPhonePad(userInput);
            Console.WriteLine($"Output: {output}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static bool IsValidInput(string input)
    {
        if (string.IsNullOrEmpty(input) || input[input.Length - 1] != '#')
            return false;

        foreach (char c in input)
        {
            if (!(char.IsDigit(c) || c == '*' || c == ' ' || c == '#'))
                return false;
        }

        return true;
    }
}
