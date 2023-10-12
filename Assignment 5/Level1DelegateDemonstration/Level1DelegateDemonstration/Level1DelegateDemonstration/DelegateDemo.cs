using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1DelegateDemonstration
{
    // Step 1: Delegate Definition
    delegate int MyDelegate(int input);

    internal class DelegateDemo
    {

        // Step 2: Method Implementations
        public static int Square(int input)
        {
            return input * input;
        }

        public static int Cube(int input)
        {
            return input * input * input;

        }
    }
}
