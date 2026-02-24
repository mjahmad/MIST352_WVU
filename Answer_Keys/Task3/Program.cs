namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ####### define variables ###################
            double dblDiscountRate = 0, dblDiscountAmnt = 0, dblOrderTotal = 0, dblShipping = 0;
            char chrMember = 'N';
            bool blnIsMember = false;
            int intItemsCount = 0;

            // ####### Input #############################
            Console.WriteLine("What is your order total?");
            dblOrderTotal = Double.Parse(Console.ReadLine());
            Console.Write("Are you a member?\n");
            chrMember = Console.ReadKey().KeyChar;
            if (chrMember.Equals('Y'))
                blnIsMember=true;
            Console.WriteLine("\nWhat is item count?");
            intItemsCount = int.Parse(Console.ReadLine());

            // ####### logic #############################
            if (blnIsMember && dblOrderTotal >= 100)
                dblDiscountRate = 0.15;
            else if (blnIsMember && dblOrderTotal < 100)
                dblDiscountRate = 0.10;
            else if (!blnIsMember && dblOrderTotal >= 150)
                dblDiscountRate = 0.5;
            // do we even need else ;) ?
            dblDiscountAmnt = dblOrderTotal * dblDiscountRate;
            //dblOrderTotal -= dblDiscountAmnt;

            if (dblDiscountAmnt < 75)
                dblShipping = 8.99;
            Console.WriteLine($"Original Total: {dblOrderTotal}\nDiscount %: {dblDiscountRate}\nDiscount Amount:{dblDiscountAmnt}\nTotal After Discount: {dblOrderTotal - dblDiscountAmnt}\nShipping: {dblShipping}\nFinal Total: {dblOrderTotal - dblDiscountAmnt + dblShipping}");


        }
    }
}
