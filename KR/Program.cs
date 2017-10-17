/*
ФИО: Костюченко Илья Игоревич
Группа: БПИ 171-1
Дата: 17.10.17
Вариант: KRmod1.1
*/

using System;
using static Iko.Console;
using static System.Console;

/*
# Alternative solution 1

Instead of printing to the console and retrning a bool, ProcessNumber could return
an array of numbers, conforming to the passed predecate.

# Alternative solution 2

ProcessNumber could take just the number as a parameter and
return an array of tuples (<number of `0`>, <number of `1`>)

# Alternative solution 3

The number of `0` and `1` can also be counted by repeatedly dividing the given number by 2.
*/

class MainClass {
    /// <summary>
    /// Counts the number of charecters that are equal to the specified character in the binary string represenattion of the given number.
    /// </summary>
    /// <returns>the number of characters</returns>
    /// <param name="number">the number to be processed</param>
    /// <param name="bit">the character represenation of the bit ti be counted</param>
    static int CountBinary(int number, char bit) {
        int outp = 0;
        foreach (char character in Convert.ToString(number, 2)) {
            if (character == bit) {
                outp += 1;
            }
        }
        return outp;
    }

    /// <summary>
    /// Counts the number of `1` in the binary represenation of the number
    /// </summary>
    /// <returns>The number of `1` in the binary represenation of the number</returns>
    /// <param name="number">The number to be processed</param>
    static int CountBinaryOnes(int number) {
        return CountBinary(number, '1');
    }

    /// <summary>
    /// Counts the number of `0` in the binary represenation of the number
    /// </summary>
    /// <returns>The number of `0` in the binary represenation of the number</returns>
    /// <param name="number">The number to be processed</param>
     static int CountBinaryZeros(int number) {
        return CountBinary(number, '0');
    }

    /// <summary>
    /// Prompts the user for a number in the range (0;10000) and returns the number.
    /// If the number does not conform to the requirements, the user will be prompted again.
    /// </summary>
    /// <returns>The number put in by the user</returns>
    /// <param name="message">A string propmpting the user for input.</param>
    /// <param name="errorMessage">A string telling the user, he didn't input correct data</param>
    static int ReadNumber(string message, string errorMessage) {
        return GetInt(message, x => x > 0 && x < 10000, errorMessage);
    }

    /// <summary>
    /// Outputs all numbers from the range (0; number], conforming to the passed function.
    /// </summary>
    /// <returns><c>true</c>, if number any number was output to the console, <c>false</c> otherwise.</returns>
    /// <param name="number">The upper-bound of the range to be tested</param>
    /// <param name="validate">The function used to test numbers</param>
    static bool ProcessNumber(int number, Func<int, int, bool> validate) {
        bool didSucceed = false;
        for (int i = 1; i <= number; i++) {
            if (validate(CountBinaryZeros(i), CountBinaryOnes(i))) {
                didSucceed = true;
                WriteLine(i);
            }
        }
        return didSucceed;
    }

    public static void Main(string[] args) {
        Repeat(() => {
            int number = ReadNumber($"Please enter a positive number smaller than 10000{Environment.NewLine}N = "
                                    , "That is not a valid positive number smaller than 10000");
            if (ProcessNumber(number, (a, b) => a == b)) {
                return;
            }
            if (ProcessNumber(number, (a, b) => a + 1 == b)) {
                return;
            }
            WriteLine("That number does not yield any results...");
        });
    }
}
