
    internal class Program
    {
        static void Main(string[] args)
        {
        //hardcode the message
        string strMsg = "WAKE UP, Neo | Location: Zion | Time: 07:45 PM | Code: #NEO-7 | Pill: Red";
        string[] splittedMsg = strMsg.Split('|');
        string strPart1 = splittedMsg[0];
        string strPart2 = splittedMsg[1];
        string strPart3 = splittedMsg[2];
        string strPart4 = splittedMsg[3];
        string strPart5 = splittedMsg[4];
        //Consider part1 (WAKE UP, Neo) => make all upper => replace the , followed by space with comma only.
        Console.WriteLine($"Alert:{strPart1.ToUpper().Replace(", ",",")}");
        //Consider Part 1, split it using comma, and return the part after the first comma
        Console.WriteLine($"Agent:{strPart1.Split(',')[1]}");



    }
}

