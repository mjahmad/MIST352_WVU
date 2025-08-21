using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;

namespace CheckoutService
{
    public class CheckoutController
    {
        public delegate void CheckoutDelegate(Order order);
        public CheckoutDelegate CheckoutProcessing = null;

        private bool requestPayment()
        {
            // Payment processing goes here
            // Payment logic is not implemented in this example
            // - simply return true to indicate payment has been received
            return true;
        }

        public void StartCheckoutProcessing(Order order)
        {
            // Perform the checkout processing
            if (this.requestPayment())
            {
                if (this.CheckoutProcessing is not null)
                {
                    this.CheckoutProcessing(order);
                }
            }
        }
    }
}
