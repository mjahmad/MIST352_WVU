using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatePI
{
    class Program
    {
        // Tuning constants:
        // If you have lots of memory, increase NUMPOINTS to improve the accuracy
        private const int NUMPOINTS = 10000000;
        private const int RADIUS = 10000;

        // Value to seed the random number generator for each calculation.
        // Using the same seed value ensures that the same results should be generated each time
        private const int SEED = 269222;

        // If you have a very fast processor, increase SPINWAITS to show the effects of parallelization
        private const int SPINWAITS = 100;

        private static double SerialPI()
        {
            List<double> pointsList = new List<double>();
            Random random = new Random(SEED);
            int numPointsInCircle = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            try
            {
                // TO DO: Implement the geometric approximation of PI
                return 0;
            }
            finally
            {
                long milliseconds = timer.ElapsedMilliseconds;
                Console.WriteLine($"SerialPI complete: Duration: {milliseconds} ms");
                Console.WriteLine($"Points in pointsList: {pointsList.Count}. Points within circle: {numPointsInCircle}");
            }
        }

        private static double ParallelPI()
        {
            List<double> pointsList = new List<double>(NUMPOINTS);
            Random random = new Random(SEED);
            int numPointsInCircle = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            try
            {
                // TO DO: Implement the geometric approximation of PI
                return 0;
            }
            finally
            {
                long milliseconds = timer.ElapsedMilliseconds;
                Console.WriteLine($"ParallelPI complete: Duration: {milliseconds} ms");
                Console.WriteLine($"Points in pointsList: {pointsList.Count}. Points within circle: {numPointsInCircle}");
            }
        }

        private static void doAdditionalProcessing()
        {
            Thread.SpinWait(SPINWAITS);
        }

        static void Main(string[] args)
        {
            double pi = SerialPI();
            Console.WriteLine("Geometric approximation of PI calculated serially: {0}", pi);

            Console.WriteLine();

            //pi = ParallelPI();
            //Console.WriteLine("Geometric approximation of PI calculated in parallel: {0}", pi);
        }
    }
}
