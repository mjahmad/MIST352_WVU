using System;

namespace Vehicles
{
    class Program
    {
        static void doWork()
        {
            Console.WriteLine("Journey by airplane:");
            Airplane myPlane = new Airplane();
            myPlane.StartEngine("Contact");
            myPlane.TakeOff();
            myPlane.Drive();
            myPlane.Land();
            myPlane.StopEngine("Whirr");

            Console.WriteLine();
            Console.WriteLine("Journey by car:");
            Car myCar = new Car();
            myCar.StartEngine("Brm brm");
            myCar.Accelerate();
            myCar.Drive();
            myCar.Brake();
            myCar.StopEngine("Phut phut");

            Console.WriteLine("\nTesting polymorphism");
            Vehicle v = myCar;
            v.Drive();
            v = myPlane;
            v.Drive();
        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
