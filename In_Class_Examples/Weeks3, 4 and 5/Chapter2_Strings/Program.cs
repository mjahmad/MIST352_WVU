// ============================================================================
// String Study Guide (No Loops, No If-Statements)
// ----------------------------------------------------------------------------
// This console app demonstrates the most important string operations in C#.
// It is designed as a STUDY GUIDE: every section has detailed documentation
// inside the code itself. You can run it and observe the output.
//
// Topics Covered:
//   1. String basics and immutability
//   2. Length and case conversion
//   3. Trimming whitespace
//   4. Substring and character access
//   5. Finding text (IndexOf, LastIndexOf)
//   6. Concatenation methods
//   7. Equality and comparisons (==, Equals)
//   8. Null/Empty/Whitespace checks
//
// Notes:
//   - Strings are IMMUTABLE (cannot be changed after creation).
//   - `==` compares CONTENT, not just references.
//   - Results are stored in `bool` variables and printed directly.
// ============================================================================

using System;

internal static class Program
{
    private static void Main()
    {
        // ──────────────────────────────
        // 1) String basics
        // ──────────────────────────────
        // A string is a sequence of characters.
        // Literals in quotes like "hi" are stored as immutable objects.
        // Example:
        string a = "  Hello World!  ";
        string b = "hi";
        string c = "HI";

        // ──────────────────────────────
        // 2) Length and Case Conversion
        // ──────────────────────────────
        // .Length → number of characters
        // .ToUpper() → new string with uppercase letters
        // .ToLower() → new string with lowercase letters
        Console.WriteLine("=== Length & Case ===");
        Console.WriteLine($"a.Length: {a.Length}");
        Console.WriteLine($"a.ToUpper(): {a.ToUpper()}");
        Console.WriteLine($"a.ToLower(): {a.ToLower()}");

        // ──────────────────────────────
        // 3) Trimming Whitespace
        // ──────────────────────────────
        // .Trim() removes whitespace at both ends.
        // .TrimStart() removes only at the beginning.
        // .TrimEnd() removes only at the end.
        Console.WriteLine("\n=== Trim ===");
        Console.WriteLine($"Original: ⟦{a}⟧");
        Console.WriteLine($"Trim():   ⟦{a.Trim()}⟧");
        Console.WriteLine($"TrimStart(): ⟦{a.TrimStart()}⟧");
        Console.WriteLine($"TrimEnd():   ⟦{a.TrimEnd()}⟧");

        // ──────────────────────────────
        // 4) Substring and Character Access
        // ──────────────────────────────
        // Strings can be sliced or indexed:
        //   s[index] → a single char
        //   s.Substring(start, length) → part of the string
        Console.WriteLine("\n=== Substring & Characters ===");
        Console.WriteLine($"a[2]: {a[2]}");              // third character (index starts at 0)
        Console.WriteLine($"a.Substring(2, 5): {a.Substring(2, 5)}");

        // ──────────────────────────────
        // 5) Finding Text
        // ──────────────────────────────
        // .IndexOf("text") → position of first match (or -1 if not found)
        // .LastIndexOf("text") → position of last match
        Console.WriteLine("\n=== Finding Text ===");
        Console.WriteLine($"a.IndexOf(\"World\"): {a.IndexOf("World")}");
        Console.WriteLine($"a.LastIndexOf(\"l\"): {a.LastIndexOf("l")}");

        // ──────────────────────────────
        // 6) Concatenation
        // ──────────────────────────────
        // There are several ways to join strings:
        //   - Using + operator
        //   - Using string.Concat
        //   - Using interpolation $"..."
        Console.WriteLine("\n=== Concatenation ===");
        string concat1 = "Hello " + "C#";
        string concat2 = string.Concat("Learn ", "Strings");
        string name = "MJ";
        string concat3 = $"Hello {name}!";
        Console.WriteLine(concat1);
        Console.WriteLine(concat2);
        Console.WriteLine(concat3);

        // ──────────────────────────────
        // 7) Equality and Comparisons
        // ──────────────────────────────
        // == compares CONTENT (not reference).
        // string.Equals can specify case sensitivity.
        string x = "hi", y = "hi";
        bool equal1 = (x == y);  // True, because both have same text
        bool equal2 = (b == c);  // False, case-sensitive check
        bool equal3 = string.Equals(b, c, StringComparison.OrdinalIgnoreCase); // True, ignores case
        Console.WriteLine("\n=== Equality ===");
        Console.WriteLine($"x == y: {equal1}");
        Console.WriteLine($"b == c: {equal2}");
        Console.WriteLine($"b vs c (ignore case): {equal3}");

        // ──────────────────────────────
        // 8) Null, Empty, and Whitespace
        // ──────────────────────────────
        // string.Empty is the empty string "".
        // string.IsNullOrEmpty(s) → true if null or "".
        // string.IsNullOrWhiteSpace(s) → also true if only spaces/tabs.
        string empty = "";
        string spaces = "   ";
        bool check1 = string.IsNullOrEmpty(empty);
        bool check2 = string.IsNullOrWhiteSpace(spaces);
        Console.WriteLine("\n=== Null/Empty/Whitespace ===");
        Console.WriteLine($"IsNullOrEmpty(empty): {check1}");
        Console.WriteLine($"IsNullOrWhiteSpace(spaces): {check2}");
    }
}
