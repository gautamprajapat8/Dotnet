using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface us = new UserInterface();
            us.Run();
        }
    }

    class Calculator
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
                return 0; // Handle division by zero gracefully
            }
            return num1 / num2;
        }
    }

    class UserInterface
    {
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayWelcomeMessage();
                int choice = DisplayMenuAndGetChoice();

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Console.Write("Enter the first number: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter the second number: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        PerformCalculation(choice, num1, num2);
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Calculator Console App!");
        }

        private int DisplayMenuAndGetChoice()
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private void PerformCalculation(int choice, double num1, double num2)
        {
            Calculator calculator = new Calculator();
            double result = 0;
            switch (choice)
            {
                case 1:
                    result = calculator.Add(num1, num2);
                    DisplayResult(result, "+", num1, num2);
                    break;
                case 2:
                    result = calculator.Subtract(num1, num2);
                    DisplayResult(result, "-", num1, num2);
                    break;
                case 3:
                    result = calculator.Multiply(num1, num2);
                    DisplayResult(result, "*", num1, num2);
                    break;
                case 4:
                    result = calculator.Divide(num1, num2);
                    DisplayResult(result, "/", num1, num2);
                    break;
            }
        }

        private void DisplayResult(double result, string operation, double num1, double num2)
        {
            Console.WriteLine($"The result of {num1} {operation} {num2} is {result:F2}\n\n"); // Display with 2 decimal places
        }
    }
}
