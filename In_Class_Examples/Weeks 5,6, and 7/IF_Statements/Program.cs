
/*
 -----------------------------------------------------------------------------
 Program Summary: Grade Calculator with Input Validation
 -----------------------------------------------------------------------------
 Purpose:
    This program asks the user to enter a numeric grade and calculates 
    the corresponding letter grade (A–F). It demonstrates safe user 
    input handling, null checks, and number conversion.

 Features:
    1. Prompts the user for a grade.
    2. Handles all input cases:
       - Null input (Ctrl+Z / Ctrl+D) → stops with a message.
       - Empty input (Enter with no text) → stops with a message.
       - Invalid input (not a number) → stops with a message.
    3. Uses Double.TryParse to safely convert text to a number.
    4. Calculates the letter grade:
          90–100 : A
          80–89  : B
          70–79  : C
          60–69  : D
          Below 60: F
    5. Displays either a clear error message or the grade result.

 Example Runs:
    Input: 88        → Output: The letter grade of 88 is B
    Input: (Enter)   → Output: You pressed Enter without typing anything.
    Input: banana    → Output: 'banana' is not a valid number.
    Input: Ctrl+Z/D  → Output: No input was provided (null).

 Learning Outcomes:
    - How to validate user input.
    - How to safely handle null and empty strings.
    - How to use Double.TryParse instead of Double.Parse.
    - How to implement decision-making with if/else statements.
 -----------------------------------------------------------------------------
*/

namespace IF_Statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a grade, I won’t be nice if you don’t provide a grade.");
            Console.WriteLine("==================Long -traditional- version ================================");


            // Ask the user for input
            Console.Write("Please type something: ");
            String? strUserInput = Console.ReadLine();

            // Check for null (Ctrl+Z or Ctrl+D)
            if (strUserInput == null)
            {
                Console.WriteLine(" No input was provided (null). Program will exit.");
                return; // Stop program
            }

            // Check for empty string
            if (strUserInput == "")
            {
                Console.WriteLine(" You pressed Enter without typing anything. Program will exit.");
                return; // Stop program
            }

            // Try to parse as double
            bool success = Double.TryParse(strUserInput, out double dblGrade);
            if (!success)
            {
                Console.WriteLine($" '{strUserInput}' is not a valid number. Program will exit.");
                return; // Stop program
            }

            // Calculate letter grade
            char chrLetterGrade;
            if (dblGrade >= 90)
                chrLetterGrade = 'A';
            else if (dblGrade >= 80)
                chrLetterGrade = 'B';
            else if (dblGrade >= 70)
                chrLetterGrade = 'C';
            else if (dblGrade >= 60)
                chrLetterGrade = 'D';
            else
                chrLetterGrade = 'F';

            Console.WriteLine($"The letter grade of {dblGrade} is {chrLetterGrade}");

            Console.WriteLine("==================Shorter version ================================");
            
            //string? strUserInput = Console.ReadLine();

            //// Validate input: null, empty, or not a number → stop
            //// Check if the input is null, empty, whitespace, OR not a valid number.
            //// If any of these are true, the program will stop.
            //// out means output parameter, the keyword out tells C# that this variable is being filled by the method TryParse NEAT STUFF
            //if (string.IsNullOrWhiteSpace(strUserInput) ||!Double.TryParse(strUserInput, out double dblGrade))
            //{
            //    Console.WriteLine(" :( Invalid input. Program will exit.");
            //    return;
            //}

            //if (dblGrade < 0 || dblGrade > 100)
            //{
            //    Console.WriteLine("Grade must be between 0 and 100. Program will exit.");
            //    return;
            //}
            
            //    // Calculate letter grade
            //    char chrLetterGrade =
            //        dblGrade >= 90 ? 'A' :
            //        dblGrade >= 80 ? 'B' :
            //        dblGrade >= 70 ? 'C' :
            //        dblGrade >= 60 ? 'D' : 'F';

            //Console.WriteLine($"The letter grade of {dblGrade} is {chrLetterGrade}");
        }
    }
}
