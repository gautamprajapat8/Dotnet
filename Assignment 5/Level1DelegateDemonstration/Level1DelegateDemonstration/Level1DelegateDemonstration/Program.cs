using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1DelegateDemonstration
{
    class Program
    {
        static void Main(string[] args)
        {


            // Step 3: Delegate Assignment
            MyDelegate squareDelegate = DelegateDemo.Square;
            MyDelegate cubeDelegate = DelegateDemo.Cube;

            // Step 4: Delegate Invocation
            int number = 5;
            int squareResult = squareDelegate(number);
            int cubeResult = cubeDelegate(number);

            // Step 5: Output
            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Square: {squareResult}");
            Console.WriteLine($"Cube: {cubeResult}");
        }
    }

}
