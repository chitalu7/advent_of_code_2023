﻿// See https://aka.ms/new-console-template for more information
















































// AoC - DAY 1 - TREBUCHET

using System.Reflection.PortableExecutable;

Console.WriteLine("ADVENT OF CODE - DAY 1 - TREBUCHET");
Console.WriteLine();

// Data Hold
List<int> dataToCalculate = new List<int>();
string firstDigit = string.Empty;
string secondDigit = string.Empty;

// Default source of input text
//string srcFolder = "C:/Users/chita/OneDrive/Documents/06-TEKITWE/Advent_Of_Code/2023/day_1/";

// Default test source file 1
//string textFile = "C:/Users/chita/OneDrive/Documents/06-TEKITWE/Advent_Of_Code/2023/day_1/sample_data_1.txt";

// Default test source file 2
//string textFile = "C:/Users/chita/OneDrive/Documents/06-TEKITWE/Advent_Of_Code/2023/day_1/sample_data_2.txt";

// Default real data source file
string textFile = "C:/Users/chita/OneDrive/Documents/06-TEKITWE/Advent_Of_Code/2023/day_1/real_data_input.txt";

if (File.Exists(textFile))
{
    int numberExtracted = 0;
    // Use a StreamReader to read the file
    using (StreamReader reader = new StreamReader(textFile))
    {
        // Loop and read each line until the end of the file is reached
        while (!reader.EndOfStream)
        {
            // Read the current line
            string line = reader.ReadLine()!;

            // Process the lineS as needed
            numberExtracted = ExtractDoubleDigitNumber(line);
            Console.WriteLine(numberExtracted);
        }

        Console.WriteLine();

        Console.WriteLine($"TOTAL VALUE: {dataToCalculate.Sum()}");


        // Read the entire contents of the file
        string content = reader.ReadToEnd();

        // Display the content
        Console.WriteLine(content);
        Console.WriteLine();
    }
}

int ExtractDoubleDigitNumber(string lineIn)
{
    // Keep track of start and end loops to find first and second digits
    int indexCount = 0;

    // String value of concatenated digit values from each line of data
    string checkValue = string.Empty;


    int result = 0;

    // Extract first digit
    foreach (char character in lineIn)
    {
        if (int.TryParse(character.ToString(), out int charToInt))
        {

            firstDigit = character.ToString();
            break;
        }
        indexCount++;
    }

    // Extract second digit
    for (int i = lineIn.Length - 1; i >= indexCount; i--)
    {
        if (int.TryParse(lineIn[i].ToString(), out int charToInt))
        {
            secondDigit = lineIn[i].ToString();
            break;
        }

    }

    // Concatenate first and second digit
    checkValue = firstDigit + secondDigit;

    // Check concatenated digits for special cases and constraints
    if (checkValue.Length == 1)
    {
        checkValue += checkValue;
    }

    if (string.IsNullOrEmpty(checkValue))
    {
        result = 0;
    }
    else if (int.TryParse(checkValue, out int numberValue))
    {
        result = numberValue;
    }
    else
    {
        Console.WriteLine("Invalid format for conversion");
    }

    dataToCalculate.Add(result);
    return result;
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
