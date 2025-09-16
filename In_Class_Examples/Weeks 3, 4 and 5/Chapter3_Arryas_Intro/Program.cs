// ============================================================================
// Arrays in C# - A Comprehensive Introduction
// ----------------------------------------------------------------------------
// This program demonstrates many fundamentals of arrays in C#.
// Topics covered:
//
//   1. Declaration vs. Initialization of arrays
//   2. Default values for arrays created with "new"
//   3. Filling arrays with data
//   4. Accessing arrays with for loops and foreach loops
//   5. Understanding i++ vs ++i (post-increment vs pre-increment)
//   6. Using arrays to calculate Sum and Average
//   7. Using the Math library (Min, Max, Pow, Sqrt, Rounding)
//   8. Array bounds checking and IndexOutOfRangeException
//   9. Useful Array helper methods (Length, IndexOf, Reverse)
//
// NOTE: Arrays are *fixed-size* collections. Once created, their size cannot
//       change. For flexible collections, see List<T>.
//
// Author: [Your Name]
// Class: MIST352
// Date: [Insert Date]
// ============================================================================

using System;

namespace ArraysDeepDiveDocumented
{
    internal class Program
    {
        static void Main()
        {
            // ----------------------------------------------------------------
            // 1) Declaration vs Initialization
            // ----------------------------------------------------------------
            // Declare an array variable but do not initialize it yet.
            // At this point, it has no memory allocated and is "null".
            int[] notCreated;

            // Assign null explicitly so we can safely check.
            notCreated = null;
            Console.WriteLine("=== 1) Declaration vs Initialization ===");
            Console.WriteLine($"notCreated is null? {notCreated is null}");

            // Initialize an array with "new" to allocate memory.
            // Now it holds 5 integers, all defaulting to 0.
            int[] numbers = new int[5];

            // A string array defaults to "null" for each element.
            string[] words = new string[3];

            // A bool array defaults to "false" for each element.
            bool[] flags = new bool[2];

            // ----------------------------------------------------------------
            // 2) Default values after initialization
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 2) Default Values After `new` ===");
            PrintArray("numbers (int[] defaults)", numbers);
            PrintArray("words (string[] defaults)", words);
            PrintArray("flags (bool[] defaults)", flags);

            // ----------------------------------------------------------------
            // 3) Filling arrays with data
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 3) Fill Arrays ===");

            // Use a for loop to assign values to the numbers array.
            for (int i = 0; i < numbers.Length; i++)
            {
                // Each element is set to (index+1)*10
                numbers[i] = (i + 1) * 10; // 10,20,30,40,50
            }

            // Manually fill in string values.
            words[0] = "Apple";
            words[1] = "Banana";
            words[2] = "Cherry";

            // Fill in boolean values.
            flags[0] = true;
            flags[1] = false;

            // Print the filled arrays.
            PrintArray("numbers (filled)", numbers);
            PrintArray("words (filled)", words);
            PrintArray("flags (filled)", flags);

            // ----------------------------------------------------------------
            // 4) Accessing arrays with for vs foreach
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 4) for vs foreach ===");

            // Using a for loop gives us access to the index.
            Console.WriteLine("for (with index):");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Index {i} -> {numbers[i]}");
            }

            // Using foreach is simpler when we just need the values.
            Console.WriteLine("foreach (no index):");
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

            // ----------------------------------------------------------------
            // 5) i++ vs ++i
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 5) i++ vs ++i (post vs pre) ===");
            int x = 0;

            // Post-increment: use x, then increment it.
            Console.WriteLine($"Start x = {x}");
            Console.WriteLine($"Post-increment x++ prints: {x++} (then x becomes {x})");

            // Pre-increment: increment x first, then use it.
            Console.WriteLine($"Pre-increment ++x prints: {++x} (x was incremented before use)");

            // Demonstrating increment in an array index.
            Console.WriteLine("\nUse them carefully in expressions:");
            int[] tiny = { 5, 6, 7 };
            int idx = 0;
            Console.WriteLine($"tiny[idx++] -> {tiny[idx++]}  (used old idx, then incremented)");
            Console.WriteLine($"tiny[++idx] -> {tiny[++idx]}  (incremented first, then used)");

            // ----------------------------------------------------------------
            // 6) Calculate sum and average using arrays
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 6) Compute Sum & Average (with Math) ===");

            int sum = 0;

            // Using a for loop to accumulate sum.
            for (int i = 0; i < numbers.Length; ++i) // pre-increment works here
            {
                sum += numbers[i];
            }

            // Avoid division by zero by checking length.
            /*(condition) ? value_if_true : value_if_false;
             * condition → must evaluate to true or false.

              If condition == true → the whole expression returns value_if_true.

               If condition == false → the whole expression returns value_if_false.
             */
            // So below, if the length of the array is zero (empty), then avg is zero. else, calcualte average.

            double avg = (numbers.Length == 0) ? 0 : (double)sum / numbers.Length;

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average (raw) = {avg}");
            Console.WriteLine($"Average (Math.Round to 2) = {Math.Round(avg, 2)}");

            // ----------------------------------------------------------------
            // 7) Math library applications
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 7) More Math tricks ===");

            // Find minimum and maximum values using Math.Min/Math.Max.
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int n in numbers)
            {
                min = Math.Min(min, n);
                max = Math.Max(max, n);
            }
            Console.WriteLine($"Min = {min}, Max = {max}");

            // Root Mean Square (RMS) using Math.Pow and Math.Sqrt.
            double sumSquares = 0;
            foreach (int n in numbers)
            {
                sumSquares += Math.Pow(n, 2); // square each number
            }
            double rms = Math.Sqrt(sumSquares / numbers.Length);
            Console.WriteLine($"RMS = {Math.Round(rms, 2)}");

            // Ceiling and floor functions.
            Console.WriteLine($"Ceiling(avg) = {Math.Ceiling(avg)}, Floor(avg) = {Math.Floor(avg)}");

            // ----------------------------------------------------------------
            // 8) Array bounds checking
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 8) Bounds Checking & Exceptions ===");

            try
            {
                // Accessing numbers[numbers.Length] would throw IndexOutOfRangeException.
                // Example: int oops = numbers[numbers.Length];
                int safeIndex = numbers.Length - 1;
                Console.WriteLine($"Safe last element numbers[{safeIndex}] = {numbers[safeIndex]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Caught index error: {ex.Message}");
            }

            // ----------------------------------------------------------------
            // 9) Array helper methods
            // ----------------------------------------------------------------
            Console.WriteLine("\n=== 9) Common Helpers ===");

            // .Length property gives array size.
            Console.WriteLine($"numbers.Length = {numbers.Length}");

            // Array.IndexOf searches for a value.
            int indexOf30 = Array.IndexOf(numbers, 30);
            Console.WriteLine($"Array.IndexOf(numbers, 30) = {indexOf30}");

            // Array.Reverse reverses the order in-place.
            Array.Reverse(numbers);
            PrintArray("numbers after Array.Reverse()", numbers);

            Console.WriteLine("\nDone!");
        }

        // --------------------------------------------------------------------
        // Helper Methods to Print Arrays
        // --------------------------------------------------------------------
        // Printing arrays nicely with labels helps visualize their contents.

        // Print int arrays
        static void PrintArray(string label, int[] arr)
        {
            Console.WriteLine($"{label}: [{string.Join(", ", arr)}]");
        }

        // Print string arrays, showing "null" explicitly.
        static void PrintArray(string label, string[] arr)
        {
            string[] shown = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                // Replace null with "null" text so students can see it.
                shown[i] = arr[i] ?? "null";
            }
            Console.WriteLine($"{label}: [{string.Join(", ", shown)}]");
        }

        // Print bool arrays
        static void PrintArray(string label, bool[] arr)
        {
            Console.WriteLine($"{label}: [{string.Join(", ", arr)}]");
        }
    }
}
