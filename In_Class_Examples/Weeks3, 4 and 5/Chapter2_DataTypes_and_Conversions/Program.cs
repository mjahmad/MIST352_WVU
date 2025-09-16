// ============================================================================
// Type Conversions & Formatting (No Loops, No If-Statements)
// ----------------------------------------------------------------------------
// PURPOSE
//   This console app demonstrates how to:
//     1) Convert values between common data types in C#
//        - Implicit numeric conversions (widening, safe)
//        - Explicit numeric casts (narrowing, may truncate/overflow)
//        - System.Convert methods
//        - Parsing from string → number/bool/DateTime/decimal
//        - TryParse pattern to avoid exceptions (reported via bool flags)
//     2) Print each data type cleanly using formatting
//        - Numeric standard format strings: C, N, F, P, X
//        - DateTime formats: short, long, custom
//        - String interpolation with alignment and precision
//        - Culture-aware formatting (invariant vs current)
//     3) Integrate user input with Console.ReadLine()
//        - Read text and attempt to parse into typed variables
//        - Report parse success with boolean variables (no branching)
//
// CONSTRAINTS
//   - No loops and no if-statements.
//   - All conditions are captured as bool variables and printed.
//
// HOW TO USE
//   - Build & run. Provide a few inputs when prompted.
//   - Observe the output and compare to the comments.
//
// REFERENCES
//   - Docs: Numeric conversions, Convert class, Parse/TryParse, format strings.
//
// NOTE
//   - This file is designed as a STUDY GUIDE embedded in code. Read the comments
//     above each section, then run and observe the corresponding outputs.
// ============================================================================

using System;
using System.Globalization;

internal static class Program
{
    private static void Main()
    {
        // ─────────────────────────────────────────────────────────────────────
        // SECTION 1: IMPLICIT vs EXPLICIT NUMERIC CONVERSIONS
        // ─────────────────────────────────────────────────────────────────────
        // Implicit (widening) conversions are safe and automatic, e.g. int -> long, int -> double.
        // Explicit (narrowing) requires a cast and can lose data, e.g. double -> int (fraction truncated).
        int? x = int.Parse(Console.ReadLine());
        Console.WriteLine(x);
        Console.WriteLine("=== 1) Numeric Conversions: Implicit vs Explicit ===");

        int i = 123;          // 32-bit signed integer
        long L = i;            // implicit: int -> long
        double dx = i;            // implicit: int -> double (123.0)
        double dy = 123.987;      // 64-bit floating point
        int j = (int)dy;      // explicit: double -> int (becomes 123; fractional part truncated)

        Console.WriteLine($"int i = 123; long L = i;      => L: {L}");
        Console.WriteLine($"int i = 123; double dx = i;   => dx: {dx}");
        Console.WriteLine($"double dy = 123.987; (int)dy  => j: {j}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 2: CONVERT CLASS (System.Convert)
        // ─────────────────────────────────────────────────────────────────────
        // Convert provides methods like ToInt32, ToDouble, ToString, etc.
        Console.WriteLine("\n=== 2) System.Convert Methods ===");

        bool flag = true;
        string fromBool = Convert.ToString(flag); // "True"
        double fromStrD = Convert.ToDouble("42.5", CultureInfo.InvariantCulture);
        int fromStrI = Convert.ToInt32("2048");

        Console.WriteLine($"Convert.ToString(true)            => \"{fromBool}\"");
        Console.WriteLine($"Convert.ToDouble(\"42.5\")         => {fromStrD}");
        Console.WriteLine($"Convert.ToInt32(\"2048\")          => {fromStrI}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 3: PARSE & TRYParse (string → typed)
        // ─────────────────────────────────────────────────────────────────────
        // Parse throws on invalid input; TryParse returns false on failure and sets out var to default.
        Console.WriteLine("\n=== 3) Parse & TryParse (string → type) ===");

        int parsedInt = int.Parse("123"); // valid; would throw if invalid
        bool okDouble = double.TryParse("3.14159",
                                        NumberStyles.Float,
                                        CultureInfo.InvariantCulture,
                                        out double parsedDouble);
        bool okBool = bool.TryParse("TrUe", out bool parsedBool);
        bool okDate = DateTime.TryParse("2025-09-03",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.AssumeLocal,
                                          out DateTime parsedDate);
        bool okDec = decimal.TryParse("199.95",
                                         NumberStyles.Number,
                                         CultureInfo.InvariantCulture,
                                         out decimal parsedDecimal);

        Console.WriteLine($"int.Parse(\"123\"): {parsedInt}");
        Console.WriteLine($"double.TryParse(\"3.14159\"): ok={okDouble}, value={parsedDouble}");
        Console.WriteLine($"bool.TryParse(\"TrUe\"):       ok={okBool},   value={parsedBool}");
        Console.WriteLine($"DateTime.TryParse(\"2025-09-03\"): ok={okDate}, value={parsedDate}");
        Console.WriteLine($"decimal.TryParse(\"199.95\"): ok={okDec},    value={parsedDecimal}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 4: STRING → CHAR and CHAR → INT (Unicode code)
        // ─────────────────────────────────────────────────────────────────────
        // Accessing individual characters and converting to numeric code points (UTF-16 code unit).
        Console.WriteLine("\n=== 4) Char Conversions ===");

        string word = "Cat";
        char first = word[0];           // 'C'
        int code = first;             // implicit char -> int (Unicode code unit)
        Console.WriteLine($"word=\"{word}\", word[0]='{first}', numeric code={code}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 5: PRETTY PRINTING / FORMATTING (NUMBERS)
        // ─────────────────────────────────────────────────────────────────────
        // Standard numeric format strings:
        //   C = Currency, N = Number with group separators, F = Fixed-point, P = Percent, X = Hex
        Console.WriteLine("\n=== 5) Numeric Formatting ===");

        int n = 255;
        double pi = Math.PI;        // ~3.141592653589793
        decimal amt = 12345.6789m;

        Console.WriteLine($"Currency (C):        {amt.ToString("C", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"Number (N):          {amt.ToString("N", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"Fixed 2 (F2):        {pi.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Percent (P1):        {(0.756).ToString("P1", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Hex (X2) of 255:     {n.ToString("X2", CultureInfo.InvariantCulture)}");

        // Interpolation with alignment and precision: {value,alignment:format}
        Console.WriteLine($"\nAligned/Precision:");
        Console.WriteLine($"|{"Label",-10}|{"Value",10}|");
        Console.WriteLine($"|{"pi F3",-10}|{pi,10:F3}|");
        Console.WriteLine($"|{"amt C",-10}|{amt,10:C}|");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 6: DATE/TIME FORMATTING
        // ─────────────────────────────────────────────────────────────────────
        // Standard and custom DateTime formats.
        Console.WriteLine("\n=== 6) DateTime Formatting ===");

        DateTime now = DateTime.Now;
        Console.WriteLine($"Short date (d):     {now.ToString("d", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"Long date (D):      {now.ToString("D", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"General (g):        {now.ToString("g", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"ISO-like:           {now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 7: USER INPUT + CONVERSIONS (no branching)
        // ─────────────────────────────────────────────────────────────────────
        // We will read three inputs as strings and attempt to convert them. Instead of branching,
        // we record the success of each conversion in a bool and print the bool + the out value.
        Console.WriteLine("\n=== 7) User Input (No Loops, No If-Statements) ===");

        Console.Write("Enter an integer: ");
        string? inputInt = Console.ReadLine();

        Console.Write("Enter a decimal amount: ");
        string? inputDec = Console.ReadLine();

        Console.Write("Enter a date (e.g., 2025-09-03): ");
        string? inputDate = Console.ReadLine();

        // TryParse patterns — the out variable holds the converted value on success, or default on failure
        bool userOkInt = int.TryParse((inputInt ?? string.Empty).Trim(),
                                        NumberStyles.Integer,
                                        CultureInfo.InvariantCulture,
                                        out int userInt);

        bool userOkDec = decimal.TryParse((inputDec ?? string.Empty).Trim(),
                                            NumberStyles.Number,
                                            CultureInfo.InvariantCulture,
                                            out decimal userDecimal);

        bool userOkDate = DateTime.TryParse((inputDate ?? string.Empty).Trim(),
                                             CultureInfo.InvariantCulture,
                                             DateTimeStyles.AssumeLocal,
                                             out DateTime userDate);

        // Booleans report whether the parse succeeded. Values are printed regardless of success.
        Console.WriteLine($"\nInt.TryParse ok={userOkInt},     value={userInt}");
        Console.WriteLine($"Decimal.TryParse ok={userOkDec}, value={userDecimal}");
        Console.WriteLine($"DateTime.TryParse ok={userOkDate}, value={userDate}");

        // Also demonstrate converting the successfully parsed values into nicely formatted strings.
        // (Even if parsing failed, the default values will be shown.)
        Console.WriteLine($"\nFormatted echo:");
        Console.WriteLine($"Integer (hex if >0 not evaluated here, just showing standard decimal): {userInt}");
        Console.WriteLine($"Decimal (C):  {userDecimal.ToString("C", CultureInfo.CurrentCulture)}");
        Console.WriteLine($"Date (D):     {userDate.ToString("D", CultureInfo.CurrentCulture)}");

        // ─────────────────────────────────────────────────────────────────────
        // SECTION 8: STRING INTERPOLATION and CONCATENATION (for completeness)
        // ─────────────────────────────────────────────────────────────────────
        // Interpolation inserts values inside $"{ ... }". Concatenation uses + or string.Concat.
        Console.WriteLine("\n=== 8) Interpolation & Concatenation ===");

        string student = "Alex";
        int score = 95;
        string report1 = $"Student {student} scored {score} / 100.";
        string report2 = "Student " + student + " scored " + score + " / 100.";
        string report3 = string.Concat("Student ", student, " scored ", score, " / 100.");

        Console.WriteLine(report1);
        Console.WriteLine(report2);
        Console.WriteLine(report3);
    }
}
