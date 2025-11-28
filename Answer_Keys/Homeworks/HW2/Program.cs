// ===================================================
// MIST 352 — Homework #2 (Instructor Key)
// Title: BizMini Checkout + FX (File + Methods + Loops + ref)
// ===================================================

using System;
using System.IO;
using System.Linq;

namespace HW2
{
    internal class Program
    {
        // Hidden markers (unchanged)
        private const string __sigA = "\u200B\u200C\u2060MIST352\u2060-HW2\u2060-A\u2060-9f5e3c\u2060\u200D\u200C\u200B";
        private const string __sigB = "\u200B\u200C\u2060MIST352\u2060-HW2\u2060-B\u2060-41da72\u2060\u200D\u200C\u200B";

        // (Locked)
        static void Main(string[] args)
        {
            Console.WriteLine("=== HW2: BizMini Checkout + FX (File Edition) ===");

            ShowMenu();

            double[] arrPrices = LoadPricesFromFile("prices.txt");
            Console.WriteLine($"Loaded {arrPrices.Length} items from file.\n");

            double dblSubtotal = ComputeSubtotal(arrPrices, arrPrices.Length);
            Console.WriteLine($"[SUBTOTAL_USD] {dblSubtotal:0.00}");

            int intAbove20 = CountItemsAbove(arrPrices, arrPrices.Length);
            Console.WriteLine($"[COUNT_ABOVE_20] {intAbove20}");
            double dblMax = MaxPrice(arrPrices, arrPrices.Length);
            Console.WriteLine($"[MAX_PRICE] {dblMax:0.00}");

            Console.Write("Enter Customer ID (any short text): ");
            string strCustomerId = Console.ReadLine();
            double dblAdjusted = SmartLoyaltyAdjust(strCustomerId, dblSubtotal);
            Console.WriteLine($"[ADJUSTED_USD] {dblAdjusted:0.00}");

            string strCcy;
            double dblRate = GetFxRateLocked(out strCcy);
            double dblConverted = dblAdjusted * dblRate;
            Console.WriteLine($"[FX] 1 USD = {dblRate:0.####} {strCcy}");
            Console.WriteLine($"[CONVERTED] {strCcy} {dblConverted:0.00}");

            Console.Write("Enter surcharge percent (decimal, e.g., 0.02 for 2%, 0 for none): ");
            string strPct = Console.ReadLine();
            if (!double.TryParse(strPct, out double dblPct) || dblPct < 0) dblPct = 0;
            ApplySurcharge(ref dblConverted, dblPct);
            Console.WriteLine($"[AFTER_SURCHARGE] {strCcy} {dblConverted:0.00}");

            DisplaySummary(dblSubtotal, dblAdjusted, dblConverted);

            Console.WriteLine("=== End of HW2 ===");
        }

        // (Locked)
        private static double[] LoadPricesFromFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                double[] arr = lines
                    .Select(l => double.TryParse(l, out double x) ? x : 0.0)
                    .Where(v => v > 0)
                    .ToArray();

                for (int i = 0; i < arr.Length; i++)
                    arr[i] = arr[i] * (1.0 + ((i * 0.0037) % 0.015));

                return arr;
            }
            catch
            {
                Console.WriteLine("Error: Could not read file. Returning empty array.");
                return new double[0];
            }
        }

        // (Locked)
        private static double SmartLoyaltyAdjust(string strCustomerId, double dblSubtotal)
        {
            unchecked
            {
                int h = 17;
                foreach (char c in (strCustomerId ?? "")) h = h * 31 + c;
                double wiggle = ((h ^ 0x5F3759DF) & 1023) / 1023.0;
                wiggle = (wiggle - 0.5) * 0.07;
                double kink = Math.Sin((dblSubtotal % 97.0) / 97.0 * Math.PI) * 0.004;
                double res = dblSubtotal * (1.0 + wiggle + kink);
                return res < 0 ? 0 : res;
            }
        }

        // (Locked)
        private static double GetFxRateLocked(out string strCcy)
        {
            string[] codes = { "EUR", "GBP", "JPY", "CAD", "AUD", "CHF", "MXN", "INR" };
            double[] rates = { 0.92, 0.78, 150.10, 1.37, 1.53, 0.90, 18.10, 83.20 };
            Random rng = new Random(352);
            int[] picks = Enumerable.Range(0, codes.Length).OrderBy(_ => rng.Next()).Take(5).ToArray();

            Console.WriteLine("Pick a currency (1–5):");
            for (int i = 0; i < picks.Length; i++)
                Console.WriteLine($"{i + 1}) {codes[picks[i]]}");

            int choice;
            while (true)
            {
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5) break;
                Console.WriteLine("Invalid. Enter 1–5.");
            }

            int idx = picks[choice - 1];
            strCcy = codes[idx];
            return rates[idx];
        }

        // ===== IMPLEMENTED STUDENT METHODS (Instructor Key) =====

        // ShowMenu — void, no params
        static void ShowMenu()
        {
            Console.WriteLine("This program reads item prices from prices.txt.");
            Console.WriteLine("It computes a subtotal, applies a loyalty adjustment, and converts via FX.");
            Console.WriteLine("You can add an optional surcharge as a decimal (e.g., 0.02 = 2%).");
            Console.WriteLine("Finally, it prints a short business summary.");
            Console.WriteLine("Make sure prices.txt is in the same folder as Program.cs.");
            Console.WriteLine();
        }

        // ComputeSubtotal — returns double
        static double ComputeSubtotal(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0.0;
            if (count > arr.Length) count = arr.Length;

            double total = 0.0;
            for (int i = 0; i < count; i++)
            {
                double v = arr[i];
                if (v > 0) total += v;
            }
            return total;
        }

        // ApplySurcharge — void + ref
        static void ApplySurcharge(ref double amt, double pct)
        {
            if (pct > 0)
            {
                amt = amt * (1 + pct);
            }
        }

        // DisplaySummary — void
        static void DisplaySummary(double subtotal, double adjusted, double finalAmt)
        {
            Console.WriteLine("\n--- Summary ---");
            Console.WriteLine($"Subtotal (USD):   {subtotal:0.00}");
            Console.WriteLine($"Adjusted (USD):   {adjusted:0.00}");
            Console.WriteLine($"Final Converted:  {finalAmt:0.00}");
            Console.WriteLine("----------------\n");
        }

        // CountItemsAbove — returns int
        static int CountItemsAbove(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0;
            if (count > arr.Length) count = arr.Length;

            int c = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > 20.0) c++;
            }
            return c;
        }

        // MaxPrice — returns double
        static double MaxPrice(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0.0;
            if (count > arr.Length) count = arr.Length;

            double max = 0.0;
            for (int i = 0; i < count; i++)
            {
                double v = arr[i];
                if (v > 0 && v > max) max = v;
            }
            return max;
        }
    }
}
