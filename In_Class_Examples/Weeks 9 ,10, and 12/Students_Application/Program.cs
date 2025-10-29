namespace Students_Application
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                // Create student with full constructor
                var s1 = new Student("S1001", "Alice Rivera", new DateTime(2002, 5, 10));
                s1.StrEmail = "alice@wvu.edu";
                s1.StrPhysicalAddress = "123 High St, Morgantown, WV";
                s1.StrMailingAddress = "PO Box 456, Morgantown, WV";

                s1.DisplayInfo();
                Console.WriteLine(s1.GetGreeting("Hello"));
                Console.WriteLine("Contact (email): " + s1.GetContact("email"));
                Console.WriteLine("Contact (mailing): " + s1.GetContact("mailing"));
                Console.WriteLine();

                // Create student using ID-only constructor
                var s2 = new Student("S1002");
                s2.StrName = "Bob Nguyen";
                s2.DtmDob = new DateTime(2005, 11, 15);
                s2.StrEmail = "bob.nguyen@students.edu";
                s2.StrPhysicalAddress = "404 College Ave, Morgantown, WV";

                s2.DisplayInfo();
                Console.WriteLine(s2.GetGreeting("Hi"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
