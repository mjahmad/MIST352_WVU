namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //using the first constrcutor (default)
            //Account act1 = new Account();
            //act1.PrintInfo();

            ////using the secoind const.
            //Account act2 = new Account(300,"Sarah Conor");
            //act2.PrintInfo();

            //using the third
            Account act3 = new Account(400, "Elizabeth Smith", 100);
            act3.Deposit(90);
            act3.Withdraw(70);
            act3.PrintInfo();

            string strName = "MJ Ahmad";
          
          
        }
    }
}
