using System;

namespace Project_1
{
    /// <summary>
    /// Shared console formatting helpers.
    /// Used by every class to keep output consistent and clean.
    /// </summary>
    internal static class ConsoleUI
    {
        // ── colour shortcuts ──────────────────────────────────────────────
        public static void SetFire()   => Console.ForegroundColor = ConsoleColor.Red;
        public static void SetWarn()   => Console.ForegroundColor = ConsoleColor.Yellow;
        public static void SetGood()   => Console.ForegroundColor = ConsoleColor.Green;
        public static void SetCyan()   => Console.ForegroundColor = ConsoleColor.Cyan;
        public static void SetDim()    => Console.ForegroundColor = ConsoleColor.DarkGray;
        public static void SetWhite()  => Console.ForegroundColor = ConsoleColor.White;
        public static void Reset()     => Console.ResetColor();

        // ── borders ──────────────────────────────────────────────────────
        public static void Header(string title)
        {
            int width = 54;
            string line = new string('═', width);
            Console.WriteLine();
            SetFire();
            Console.WriteLine("╔" + line + "╗");
            Console.Write("║");
            SetWhite();
            string centered = title.PadLeft((width + title.Length) / 2).PadRight(width);
            Console.Write(centered);
            SetFire();
            Console.WriteLine("║");
            Console.WriteLine("╚" + line + "╝");
            Reset();
        }

        public static void Section(string title)
        {
            Console.WriteLine();
            SetCyan();
            Console.WriteLine("  ┌─── " + title + " " + new string('─', Math.Max(0, 44 - title.Length)) + "┐");
            Reset();
        }

        public static void SectionEnd()
        {
            SetCyan();
            Console.WriteLine("  └" + new string('─', 52) + "┘");
            Reset();
        }

        public static void Divider()
        {
            SetDim();
            Console.WriteLine("  " + new string('─', 52));
            Reset();
        }

        // ── labelled value row ────────────────────────────────────────────
        public static void Row(string label, string value, ConsoleColor valueColor = ConsoleColor.White)
        {
            SetDim();
            Console.Write("  │  ");
            Reset();
            Console.Write((label + ":").PadRight(20));
            Console.ForegroundColor = valueColor;
            Console.WriteLine(value);
            Reset();
        }

        // ── score bar ────────────────────────────────────────────────────
        public static void ScoreBar(string label, int score, int maxScore = 100)
        {
            int filled = (int)((double)score / maxScore * 30);
            string bar = new string('█', filled) + new string('░', 30 - filled);

            SetDim();
            Console.Write("  │  ");
            Reset();
            Console.Write((label + ":").PadRight(14));

            // colour the bar by score level
            if      (score >= 80) SetGood();
            else if (score >= 50) SetWarn();
            else                  SetFire();

            Console.Write(bar);
            Reset();
            Console.WriteLine($"  {score}/{maxScore}");
        }

        // ── status badge ─────────────────────────────────────────────────
        public static void Badge(string text, ConsoleColor color)
        {
            Console.Write("  ");
            Console.ForegroundColor = color;
            Console.Write($"[ {text} ]");
            Reset();
            Console.WriteLine();
        }

        // ── warning / tip lines ───────────────────────────────────────────
        public static void Warn(string msg)
        {
            SetWarn();
            Console.WriteLine("  ⚠  " + msg);
            Reset();
        }

        public static void Good(string msg)
        {
            SetGood();
            Console.WriteLine("  ✓  " + msg);
            Reset();
        }

        public static void Info(string msg)
        {
            SetCyan();
            Console.WriteLine("  ℹ  " + msg);
            Reset();
        }

        public static void FireLine(string msg)
        {
            SetFire();
            Console.WriteLine("  🔥 " + msg);
            Reset();
        }

        // ── pause ─────────────────────────────────────────────────────────
        public static void PressEnter()
        {
            Console.WriteLine();
            SetDim();
            Console.Write("  Press ENTER to return to menu...");
            Reset();
            Console.ReadLine();
        }
    }
}
