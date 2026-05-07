namespace Project_2
{
    internal static class ConsoleUI
    {
        public static void Header(string title)
        {
            int width = 58;
            string border = new string('═', width);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║{Center(title, width)}║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        public static void Section(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  ── {title} ──");
            Console.ResetColor();
        }

        public static void Info(string label, string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  {label,-22}");
            Console.ResetColor();
            Console.WriteLine(value);
        }

        public static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  [+] {msg}");
            Console.ResetColor();
        }

        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"  [!] {msg}");
            Console.ResetColor();
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  [x] {msg}");
            Console.ResetColor();
        }

        public static void Divider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  " + new string('─', 54));
            Console.ResetColor();
        }

        public static void Prompt(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n  {msg} > ");
            Console.ResetColor();
        }

        public static void MenuItem(string key, string label, string? tag = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"  [{key}]");
            Console.ResetColor();
            Console.Write($" {label,-38}");
            if (tag != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(tag);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public static void Colored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static string ProgressBar(double value, double max, int width = 20)
        {
            int filled = (int)Math.Round((value / max) * width);
            filled = Math.Clamp(filled, 0, width);
            return "[" + new string('█', filled) + new string('░', width - filled) + "]";
        }

        public static void WaitForKey(string msg = "Press any key to return to menu...")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n  {msg}");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        private static string Center(string text, int width)
        {
            if (text.Length >= width) return text;
            int pad = (width - text.Length) / 2;
            return text.PadLeft(text.Length + pad).PadRight(width);
        }

        public static void Loading(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"\n  {msg}");
            Console.ResetColor();
        }

        public static void Done() => Console.WriteLine(" done.");
    }
}
