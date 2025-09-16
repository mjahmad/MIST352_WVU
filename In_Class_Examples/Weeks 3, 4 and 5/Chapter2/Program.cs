// C# Data Types Playground (Chapter 2 companion, FLATTENED + DOCUMENTED)
// -----------------------------------------------------------------------
// Everything runs inside Main() in a straight line — no custom methods yet.
// Use the big banners in the output to see where each topic begins.
// You can comment out whole sections with /* ... */ if you want to run less.
// -----------------------------------------------------------------------

using System;            // Gives access to Console, basic types, etc.
using System.Text;       // Gives access to StringBuilder and encodings

namespace DataTypesPlayground
{
    internal static class Program
    {
        static void Main()
        {
            // Allow the console to print Unicode characters (e.g., Ω)
            Console.OutputEncoding = Encoding.UTF8;

            // Helper strings to make section banners more readable
            string line = new string('═', 90);

            // =====================================================================
            // Type Name Forms
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("TYPE NAME FORMS (aliases vs System.*)");
            Console.WriteLine(line);

            int a = 42;                  // 'int' is the C# alias for System.Int32
            System.Int32 b = 42;         // Fully-qualified CLR type name for the same thing
            Console.WriteLine($"int == System.Int32 ? {(a.GetType() == b.GetType())}");

            // =====================================================================
            // Integer Types (signed vs unsigned) + Literals
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("INTEGER TYPES (signed vs unsigned) + LITERALS");
            Console.WriteLine(line);

            // Min/Max ranges come from the type itself
            Console.WriteLine($"sbyte: {sbyte.MinValue} to {sbyte.MaxValue}   (8-bit SIGNED)");
            Console.WriteLine($"byte : {byte.MinValue}  to {byte.MaxValue}    (8-bit UNSIGNED)");
            Console.WriteLine($"int  : {int.MinValue}  to {int.MaxValue}     (32-bit SIGNED)");
            Console.WriteLine($"uint : {uint.MinValue} to {uint.MaxValue}    (32-bit UNSIGNED)");

            // Same number written in different literal forms
            int dec = 1_000_000;         // decimal with digit separators for readability
            int hex = 0xFF_FF;           // hexadecimal literal (0x prefix)
            int bin = 0b_1010_0001;      // binary literal (0b prefix)
            Console.WriteLine($"dec:{dec}, hex:{hex}, bin:{bin}");

            // Overflow demonstration
            unchecked                     // In 'unchecked', overflow wraps around
            {
                byte x = 255;             // Largest value for byte
                x++;                      // 255 + 1 => 0 (wraps)
                Console.WriteLine($"unchecked overflow (255+1) => {x}");
            }
            try
            {
                checked                   // In 'checked', overflow throws an exception
                {
                    byte y = 255;
                    y++;                  // This line throws OverflowException
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("checked overflow throws OverflowException");
            }

            // =====================================================================
            // Floating-Point Types (IEEE 754) — float & double
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("FLOATING-POINT TYPES (float, double)");
            Console.WriteLine(line);

            float f = 3.1415927f;         // 'f' suffix makes it a float (about 7 digits of precision)
            double g = 3.14159265358979;  // default real literal type is double (~15-16 digits)
            Console.WriteLine($"float : {f}");
            Console.WriteLine($"double: {g}");

            // Special values: Infinity and NaN
            Console.WriteLine($"1.0/0.0 => {1.0 / 0.0} (Infinity)");
            Console.WriteLine($"0.0/0.0 => {0.0 / 0.0} (NaN — not a number)");

            // =====================================================================
            // Decimal Type (base-10, good for money)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("DECIMAL TYPE (financial calculations)");
            Console.WriteLine(line);

            decimal price = 19.99m;       // 'm' suffix makes a decimal literal
            decimal tax = 0.06m;        // also decimal
            decimal total = price * (1 + tax);
            Console.WriteLine($"Total with tax (decimal) = {total}");

            // Show why decimal differs from double for money
            double priceD = 19.99; double taxD = 0.06; double totalD = priceD * (1 + taxD);
            Console.WriteLine($"Total with tax (double)  = {totalD}");

            // =====================================================================
            // Literal Values (char, string, verbatim, interpolated, raw)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("LITERAL VALUES (char & string forms)");
            Console.WriteLine(line);

            char letter = 'A';            // Single quotes for char
            char omega = '\u03A9';       // Unicode escape (Ω)
            Console.WriteLine($"Chars => '{letter}', '{omega}'");

            string normal = "C:\\Users\\MJ";    // Escaped backslashes
            string verbatim = @"C:\Users\MJ";    // Verbatim string (no escaping for \\)
            string interpolated = $"2+2={2 + 2}";   // Interpolated string embeds expressions
            Console.WriteLine(normal);
            Console.WriteLine(verbatim);
            Console.WriteLine(interpolated);

            // Raw string literal (C# 11+) keeps quotes/whitespace as-is
            string raw = """
                SELECT *
                FROM Users
                WHERE Name = ""MJ"";
                """;
            Console.WriteLine("Raw string literal example:\n" + raw);

            // =====================================================================
            // Boolean Type (true/false) and short-circuit logic
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("BOOLEAN TYPE");
            Console.WriteLine(line);

            bool isEven = (10 % 2 == 0);  // true because remainder is 0
            Console.WriteLine($"10 is even? {isEven}");

            // =====================================================================
            // Character Type helpers
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("CHARACTER TYPE");
            Console.WriteLine(line);

            char c = '9';
            Console.WriteLine($"'{c}' IsDigit:{char.IsDigit(c)}  IsLetter:{char.IsLetter(c)}");

            // =====================================================================
            // Strings (immutability, StringBuilder, formatting)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("STRINGS (immutability & building)");
            Console.WriteLine(line);

            string aStr = "Hello";        // Strings are reference types and immutable
            string bStr = aStr;            // bStr points to the same string as aStr ("Hello")
            aStr += ", world";            // Creates a NEW string; bStr remains "Hello"
            Console.WriteLine($"a:{aStr} | b:{bStr} (b unchanged)");

            // Efficient concatenation for loops
            var sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(i).Append(", ");
            }
            Console.WriteLine("StringBuilder => " + sb.ToString().TrimEnd(',', ' '));

            // Format and alignment in interpolation
            int n = 42; double ratio = 1.0 / 3;
            Console.WriteLine($"n = {n,6} | ratio = {ratio:P2}"); // right-align width 6, percent with 2 decimals

            // =====================================================================
            // null and void (nullable value types, ??, ?.)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("NULL AND VOID (nullable, ??, ?.)");
            Console.WriteLine(line);

            int? maybe = null;            // Nullable int can hold null
            Console.WriteLine($"maybe ?? -1 => {maybe ?? -1}"); // if null, use -1

            string? name = null;          // Nullable reference (enabled by modern C#)
            Console.WriteLine($"name?.Length ?? 0 => {name?.Length ?? 0}"); // safe access

            Console.WriteLine("Void example: this line just prints and returns nothing.");

            // =====================================================================
            // Conversions — Explicit (casts)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("CONVERSIONS — EXPLICIT CASTS");
            Console.WriteLine(line);

            double bigPi = 3.14159;       // A double value
            int truncated = (int)bigPi;   // Narrowing conversion — fractional part is dropped
            Console.WriteLine($"(int)3.14159 => {truncated}");

            char ch = 'A';                // Character literal
            int code = (int)ch;           // char -> int gives the UTF-16 code point (65)
            Console.WriteLine($"'A' => {code}, (char)66 => {(char)66}");

            // =====================================================================
            // Conversions — Implicit (widening)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("CONVERSIONS — IMPLICIT (SAFE/WIDENING)");
            Console.WriteLine(line);

            int iVal = 123;               // 32-bit int
            long lVal = iVal;             // int -> long (no data loss)
            double dVal = lVal;           // long -> double (may round for very large values, but implicit)
            Console.WriteLine($"int→long:{lVal}, long→double:{dVal}");

            // =====================================================================
            // Conversion Without Casting (Parse, TryParse, Convert, ToString)
            // =====================================================================
            Console.WriteLine(line);
            Console.WriteLine("CONVERSION WITHOUT CASTING (Parse/TryParse/Convert/ToString)");
            Console.WriteLine(line);

            // Convert value to string
            int count = 256;
            Console.WriteLine($"ToString => '{count.ToString()}'");

            // Parse a valid integer string
            string txt = "1024";
            int parsed = int.Parse(txt);  // throws if the string is not a valid number
            Console.WriteLine($"int.Parse('1024') => {parsed}");

            // TryParse for safe parsing (does NOT throw)
            if (int.TryParse("oops", out int res))
                Console.WriteLine($"TryParse success => {res}");
            else
                Console.WriteLine("int.TryParse('oops') => false");

            // Convert class handles rounding for floating → integer
            double val = 4.6;
            Console.WriteLine($"Convert.ToInt32(4.6) => {Convert.ToInt32(val)}  (rounds to nearest)");

            Console.WriteLine();
            Console.WriteLine("All demos completed. Comment out any section above to focus.");
        }
    }
}
