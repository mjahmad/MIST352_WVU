using System;

class Program
{
    static void Main()
    {
        // ===============================================================
        // C# EXAM REVIEW MEGA-FILE  (variables use 3-letter type prefixes)
        // Prefixes used: str=string, int=int, dbl=double, chr=char, bln=bool
        // HOW TO USE:
        // - Uncomment ONE section at a time (between /* ... */) by highlighting the section and hit CTRL + SHIFT + / 
        // - Run, study the output, then re-comment and try the next.
        // ===============================================================



        // ### 1) Variables & Types – Total Price
        // WHAT: Declares numbers, computes totals, prints with formatting.
        // WHY: Practice declare vs initialize, arithmetic, and {value:F2}.
        {
            Console.WriteLine("### 1) Variables & Types – Total Price");

            double dblUnitPrice = 19.99;   // price per item
            int intQuantity = 3;       // count of items
            double dblDiscountRate = 0.10; // 10% as fraction

            double dblSubtotal = dblUnitPrice * intQuantity;
            double dblDiscountAmount = dblSubtotal * dblDiscountRate;
            double dblFinalTotal = dblSubtotal - dblDiscountAmount;

            Console.WriteLine($"Subtotal: {dblSubtotal:F2}");
            Console.WriteLine($"Discount: {dblDiscountAmount:F2}");
            Console.WriteLine($"Final Total: {dblFinalTotal:F2}");
        }



        /*
        // ### 2) Syntax vs Logic vs Runtime – Spot the Difference
        // WHAT: Shows what each error type looks like.
        {
            Console.WriteLine("### 2) Syntax vs Logic vs Runtime (read comments)");

            // SYNTAX ERROR example (won't compile):
            // int intX = "5"; // ❌ cannot put string into int

            // RUNTIME ERROR example (compiles, crashes while running):
            // int intA = 5, intB = 0;
            // Console.WriteLine(intA / intB); // ❌ Division by zero

            // LOGIC ERROR example (compiles, wrong formula):
            double dblFahrenheitWrong = (5.0 / 9.0) * 30 + 32; // ❌ wrong
            double dblFahrenheitRight = (9.0 / 5.0) * 30 + 32; // ✅ correct
            Console.WriteLine($"Wrong: {dblFahrenheitWrong}, Right: {dblFahrenheitRight}");
        }
        */


        /*
        // ### 3) Input Parsing – Age & GPA (with validation)
        // WHAT: Console.ReadLine gives strings; use TryParse to validate.
        {
            Console.WriteLine("### 3) Input Parsing – Age & GPA with validation");

            int intAge;
            while (true)
            {
                Console.Write("Enter age (int): ");
                string? strInput = Console.ReadLine();
                if (int.TryParse(strInput, out intAge)) break;
                Console.WriteLine("Invalid age. Try again.");
            }

            double dblGpa;
            while (true)
            {
                Console.Write("Enter GPA (double): ");
                string? strInput = Console.ReadLine();
                if (double.TryParse(strInput, out dblGpa)) break;
                Console.WriteLine("Invalid GPA. Try again.");
            }

            Console.WriteLine($"Age: {intAge}, GPA: {dblGpa:F2}");
        }
        */


        /*
        // ### 4) Strings – Clean and Format Full Name (inline only, no methods)
        // WHAT: Trim, capitalize first letter, lowercase rest.
        {
            Console.WriteLine("### 4) Strings – Clean and Format Name");

            // FIRST NAME
            Console.Write("First name: ");
            string? strFirst = Console.ReadLine();
            if (strFirst == null) strFirst = "";
            strFirst = strFirst.Trim();
            if (strFirst.Length > 0)
            {
                string strFirstRest = (strFirst.Length > 1) ? strFirst.Substring(1).ToLower() : "";
                strFirst = char.ToUpper(strFirst[0]) + strFirstRest;
            }

            // LAST NAME
            Console.Write("Last name: ");
            string? strLast = Console.ReadLine();
            if (strLast == null) strLast = "";
            strLast = strLast.Trim();
            if (strLast.Length > 0)
            {
                string strLastRest = (strLast.Length > 1) ? strLast.Substring(1).ToLower() : "";
                strLast = char.ToUpper(strLast[0]) + strLastRest;
            }

            Console.WriteLine($"Hello, {strFirst} {strLast}!");
        }
        */


        /*
        // ### 5) Strings – Top 10 Methods Practice
        // WHAT: Trim, ToUpper, ToLower, Substring, IndexOf, Contains,
        //       Replace, Split, Join, Length
        {
            Console.WriteLine("### 5) Strings – Top 10 Methods Practice");

            Console.Write("Enter a sentence: ");
            string? strS = Console.ReadLine();
            if (strS == null) strS = "";

            strS = strS.Trim(); // Trim
            Console.WriteLine($"Length: {strS.Length}"); // Length

            int intFirstSpace = strS.IndexOf(' '); // IndexOf
            Console.WriteLine($"First space at: {intFirstSpace}");

            string strFirstWord = (intFirstSpace > 0) ? strS.Substring(0, intFirstSpace) : strS; // Substring
            Console.WriteLine($"First word: {strFirstWord}");

            Console.WriteLine($"Upper: {strS.ToUpper()}"); // ToUpper
            Console.WriteLine($"Lower: {strS.ToLower()}"); // ToLower

            Console.WriteLine($"Contains 'app': {strS.Contains("app")}"); // Contains

            string strDashed = strS.Replace(" ", "-"); // Replace
            Console.WriteLine($"Dashed: {strDashed}");

            string[] strWords = strS.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split
            Console.WriteLine($"Words count: {strWords.Length}");

            string strRejoined = string.Join("|", strWords); // Join
            Console.WriteLine($"Rejoined: {strRejoined}");
        }
        */


        /*
        // ### 6) Data Type Conversion – Patterns & Pitfalls
        // WHAT: implicit/explicit casts, Convert, Parse/TryParse, formatting.
        {
            Console.WriteLine("### 6) Data Type Conversion – Patterns & Pitfalls");

            // IMPLICIT (widening): int -> double
            int    intSmall = 42;
            double dblBig   = intSmall;
            Console.WriteLine($"Implicit int -> double: {intSmall} -> {dblBig}");

            // EXPLICIT (narrowing): double -> int (truncates)
            double dblD1 = 12.9;
            int    intI1 = (int)dblD1; // 12
            Console.WriteLine($"Explicit double -> int (cast): {dblD1} -> {intI1} (truncates)");

            // Convert rounds to nearest (banker's rounding: .5 to even)
            Console.WriteLine($"Convert.ToInt32(2.9) = {Convert.ToInt32(2.9)}  // 3");
            Console.WriteLine($"Convert.ToInt32(2.5) = {Convert.ToInt32(2.5)}  // 2 (to even)");
            Console.WriteLine($"Convert.ToInt32(3.5) = {Convert.ToInt32(3.5)}  // 4 (to even)");

            Console.WriteLine($"Convert.ToDouble(\"3.14\") = {Convert.ToDouble("3.14")}");

            // Parse vs TryParse
            int intParsedOk = int.Parse("123");
            Console.WriteLine($"int.Parse(\"123\") = {intParsedOk}");
            // int.Parse("abc"); // ❌ would throw

            bool blnOk = int.TryParse("456", out int intParsedNum);
            Console.WriteLine($"int.TryParse(\"456\") => {blnOk}, value={intParsedNum}");

            bool blnOk2 = int.TryParse("forty", out int intBadNum);
            Console.WriteLine($"int.TryParse(\"forty\") => {blnOk2}, value={intBadNum} (unchanged if false)");

            // Bool conversions
            bool blnTry1 = bool.TryParse("true", out bool blnVal1);
            Console.WriteLine($"bool.TryParse(\"true\") => {blnTry1}, value={blnVal1}");

            bool blnTry2 = bool.TryParse("0", out bool blnVal2);
            Console.WriteLine($"bool.TryParse(\"0\") => {blnTry2}, value={blnVal2}  // false & value=false");

            // Char from string
            string strDigit = "7";
            char   chrDigit = strDigit.Length > 0 ? strDigit[0] : '?';
            Console.WriteLine($"Char from \"7\" => '{chrDigit}'");

            // ToString formatting
            double dblPrice = 19.9876;
            Console.WriteLine("ToString formats:");
            Console.WriteLine(dblPrice.ToString("F2")); // 19.99
            Console.WriteLine(dblPrice.ToString("C2")); // currency (culture-based)
            Console.WriteLine((0.853).ToString("P1"));  // 85.3%

            // Summary:
            // (int)2.9 => 2 (truncate)
            // Convert.ToInt32(2.9) => 3 (round); 2.5 => 2; 3.5 => 4
        }
        */


        /*
        // ### 7) Reading Input – Convert to Proper Types (with safe defaults)
        // WHAT: TryParse user input to avoid crashes, show formatting differences.
        {
            Console.WriteLine("### 7) Reading Input – Convert to Proper Types");

            Console.Write("Enter an integer (e.g., 42): ");
            string? strInt = Console.ReadLine();
            int intVal = 0;
            if (!int.TryParse(strInt, out intVal))
            {
                Console.WriteLine("Invalid integer. Defaulting to 0.");
            }

            Console.Write("Enter a double (e.g., 3.14): ");
            string? strDouble = Console.ReadLine();
            double dblVal = 0.0;
            if (!double.TryParse(strDouble, out dblVal))
            {
                Console.WriteLine("Invalid double. Defaulting to 0.0.");
            }

            Console.WriteLine("As plain: " + dblVal);
            Console.WriteLine($"As F2: {dblVal:F2}");
            Console.WriteLine($"As Currency C2: {dblVal:C2}");

            Console.WriteLine($"Integer: {intVal}, Double: {dblVal:F2}");
        }
        */


        /*
        // ### 8) Arrays – Read 5 Integers & Compute Average/Min/Max
        // WHAT: Fill array from input; compute sum/avg/min/max using for-loops.
        {
            Console.WriteLine("### 8) Arrays – Read 5 Integers & Compute Average/Min/Max");

            int[] intNums = new int[5];
            for (int intIndex = 0; intIndex < intNums.Length; intIndex++)
            {
                Console.Write($"Enter integer #{intIndex + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out intNums[intIndex]))
                {
                    Console.Write("Invalid. Enter integer: ");
                }
            }

            int intSum = 0, intMin = intNums[0], intMax = intNums[0];
            for (int intIndex = 0; intIndex < intNums.Length; intIndex++)
            {
                intSum += intNums[intIndex];
                if (intNums[intIndex] < intMin) intMin = intNums[intIndex];
                if (intNums[intIndex] > intMax) intMax = intNums[intIndex];
            }

            double dblAvg = (double)intSum / intNums.Length;
            Console.WriteLine($"Avg: {dblAvg:F2}, Min: {intMin}, Max: {intMax}");
        }
        */


        /*
        // ### 9) Arrays – Fixed Size & "Resize" by Copying
        // WHAT: Arrays are fixed; to grow, make a new one and copy values.
        {
            Console.WriteLine("### 9) Arrays – Fixed Size (Resize by New Array)");

            int[] intA = new int[4] { 1, 2, 3, 4 };
            int[] intB = new int[7]; // larger array
            for (int intIndex = 0; intIndex < intA.Length; intIndex++)
            {
                intB[intIndex] = intA[intIndex];
            }
            Console.WriteLine(string.Join(",", intB)); // 1,2,3,4,0,0,0
        }
        */


        /*
        // ### 10) For-Loop – Reverse Print
        // WHAT: Iterate backwards (init; condition; decrement).
        {
            Console.WriteLine("### 10) For-Loop – Reverse Print");

            int[] intArr = { 10, 20, 30, 40, 50 };
            for (int intIndex = intArr.Length - 1; intIndex >= 0; intIndex--)
            {
                Console.WriteLine(intArr[intIndex]);
            }
        }
        */


        /*
        // ### 11) For-Loop + If – Count Above Threshold
        // WHAT: Read N numbers, count how many > threshold.
        {
            Console.WriteLine("### 11) For-Loop – Count Above Threshold");

            Console.Write("How many numbers? ");
            string? strN = Console.ReadLine();
            int intN = 0;
            if (!int.TryParse(strN, out intN) || intN < 0) intN = 0;

            int[] intA = new int[intN];
            for (int intIndex = 0; intIndex < intN; intIndex++)
            {
                Console.Write($"a[{intIndex}] = ");
                while (!int.TryParse(Console.ReadLine(), out intA[intIndex]))
                {
                    Console.Write("Invalid. Enter integer: ");
                }
            }

            Console.Write("Threshold t: ");
            int intThreshold;
            if (!int.TryParse(Console.ReadLine(), out intThreshold)) intThreshold = 0;

            int intCount = 0;
            for (int intIndex = 0; intIndex < intA.Length; intIndex++)
            {
                if (intA[intIndex] > intThreshold) intCount++;
            }

            Console.WriteLine($"Count > {intThreshold} = {intCount}");
        }
        */


        /*
        // ### 12) Conditionals – Grade Converter with Validation
        // WHAT: Read 0–100, validate, map to letter.
        {
            Console.WriteLine("### 12) Conditionals – Grade Converter with Validation");

            Console.Write("Enter grade (0-100): ");
            int intGrade;
            if (!int.TryParse(Console.ReadLine(), out intGrade) || intGrade < 0 || intGrade > 100)
            {
                Console.WriteLine("Invalid grade.");
            }
            else
            {
                char chrLetter;
                if (intGrade >= 90)      chrLetter = 'A';
                else if (intGrade >= 80) chrLetter = 'B';
                else if (intGrade >= 70) chrLetter = 'C';
                else if (intGrade >= 60) chrLetter = 'D';
                else                     chrLetter = 'F';

                Console.WriteLine($"Letter: {chrLetter}");
            }
        }
        */


        /*
        // ### 13) If/Else + Arrays – Pass/Fail Summary (5 grades)
        // WHAT: Read 5 grades (0–100), print letter and PASS/FAIL.
        {
            Console.WriteLine("### 13) If/Else + Arrays – Pass/Fail Summary");

            int[] intGrades = new int[5];
            for (int intIndex = 0; intIndex < intGrades.Length; intIndex++)
            {
                Console.Write($"Grade #{intIndex + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out intGrades[intIndex]) || intGrades[intIndex] < 0 || intGrades[intIndex] > 100)
                {
                    Console.Write("Invalid (0-100). Enter again: ");
                }
            }

            for (int intIndex = 0; intIndex < intGrades.Length; intIndex++)
            {
                char chrLetter;
                if (intGrades[intIndex] >= 90)      chrLetter = 'A';
                else if (intGrades[intIndex] >= 80) chrLetter = 'B';
                else if (intGrades[intIndex] >= 70) chrLetter = 'C';
                else if (intGrades[intIndex] >= 60) chrLetter = 'D';
                else                                 chrLetter = 'F';

                string strStatus = (intGrades[intIndex] >= 60) ? "PASS" : "FAIL";
                Console.WriteLine($"Grade: {intGrades[intIndex]} => {chrLetter} ({strStatus})");
            }
        }
        */


        /*
        // ### 14) Output – Concatenation vs Interpolation
        // WHAT: Show both ways to build display strings.
        {
            Console.WriteLine("### 14) Output – Interpolation vs Concatenation");

            string strName = "Alice";
            double dblScore = 93.5;

            // Concatenation
            Console.WriteLine("Name: " + strName + " | Score: " + dblScore.ToString("F2"));

            // Interpolation
            Console.WriteLine($"Name: {strName} | Score: {dblScore:F2}");
        }
        */


        /*
        // ### 15) i++ vs ++i – Order of Operations
        // WHAT: Post-increment returns old value; pre-increment increments first.
        {
            Console.WriteLine("### 15) i++ vs ++i – Predict and Check");

            int intI = 3;
            Console.WriteLine(intI++); // prints 3, then intI becomes 4
            Console.WriteLine(++intI); // intI becomes 5, then prints 5
            Console.WriteLine(intI);   // prints 5
        }
        */


        /*
        // ### 16) Mixed Practice – Clean Inputs, Build a Summary (no methods)
        // WHAT: Name cleanup, validated qty/price, formatted total.
        {
            Console.WriteLine("### 16) Mixed Practice – Clean Inputs, Build a Summary");

            Console.Write("Product name: ");
            string? strName = Console.ReadLine();
            if (strName == null) strName = "";
            strName = strName.Trim();
            if (strName.Length > 0)
            {
                string strRest = (strName.Length > 1) ? strName.Substring(1).ToLower() : "";
                strName = char.ToUpper(strName[0]) + strRest;
            }

            Console.Write("Quantity: ");
            int intQty;
            while (!int.TryParse(Console.ReadLine(), out intQty))
            {
                Console.Write("Invalid. Quantity: ");
            }

            Console.Write("Unit price: ");
            double dblPrice;
            while (!double.TryParse(Console.ReadLine(), out dblPrice))
            {
                Console.Write("Invalid. Unit price: ");
            }

            double dblTotal = intQty * dblPrice;
            Console.WriteLine($"Product: {strName} | Qty: {intQty} | Price: {dblPrice:F2} | Total: {dblTotal:F2}");
        }
        }


        /*
        // ### 17) Comments & Readability – Explain Each Step
        // WHAT: Read 3 prices, compute sum & average, print nicely.
        {
            Console.WriteLine("### 17) Comments & Readability – Add Comments");

            // Read three prices with validation
            double dblP1, dblP2, dblP3;

            Console.Write("Price #1: ");
            while (!double.TryParse(Console.ReadLine(), out dblP1))
                Console.Write("Invalid. Price #1: ");

            Console.Write("Price #2: ");
            while (!double.TryParse(Console.ReadLine(), out dblP2))
                Console.Write("Invalid. Price #2: ");

            Console.Write("Price #3: ");
            while (!double.TryParse(Console.ReadLine(), out dblP3))
                Console.Write("Invalid. Price #3: ");

            // Compute total and average
            double dblSum = dblP1 + dblP2 + dblP3;
            double dblAvg = dblSum / 3.0;

            Console.WriteLine($"Total = {dblSum:F2}, Average = {dblAvg:F2}");
        }
        */


        // END — Practice one block at a time.
        // Study tips:
        // - Use intIndex with arrays and keep loops within 0..Length-1.
        // - Prefer TryParse for user input; avoid crashes.
        // - Print intermediate values to catch logic errors quickly.
    }
}
