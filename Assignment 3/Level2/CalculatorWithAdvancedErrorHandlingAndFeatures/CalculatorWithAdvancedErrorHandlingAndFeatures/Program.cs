using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithAdvancedErrorHandlingAndFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Run();
        }
    }

    class Calculator
    {
        private double memoryStore = 0; // Variable to store a value in memory
        private double memoryRecall = 0; // Variable to recall a value from memory
        private List<string> historyLog = new List<string>(); // History log for calculations

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
                throw new Exception("Division by zero is not allowed.\n\n");
            }
            return num1 / num2;
        }

        public double InchesToCentimeters(double inches)
        {
            // Conversion logic: 1 inch = 2.54 centimeters
            return inches * 2.54;
        }

        public double PoundsToKilograms(double pounds)
        {
            // Conversion logic: 1 pound = 0.453592 kilograms
            return pounds * 0.453592;
        }

        public void StoreInMemory(double value)
        {
            memoryStore = value;
        }

        public double RecallFromMemory()
        {
            memoryRecall = memoryStore;
            return memoryRecall;
        }

        public void AddToHistoryLog(string calculation)
        {
            historyLog.Add(calculation);
        }

        public List<string> GetHistoryLog()
        {
            return historyLog;
        }
    }

    class UserInterface
    {
        private Calculator calculator = new Calculator();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
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
                            Console.WriteLine("Unit Conversion:");
                            Console.WriteLine("1. Inches to Centimeters");
                            Console.WriteLine("2. Pounds to Kilograms");
                            Console.Write("Enter your choice (1-2): ");
                            int conversionChoice = Convert.ToInt32(Console.ReadLine());
                            PerformUnitConversion(conversionChoice);
                            break;
                        case 6:
                            Console.WriteLine("Memory Functions:");
                            Console.WriteLine("1. Store Result to Memory");
                            Console.WriteLine("2. Recall Result from Memory");
                            Console.Write("Enter your choice (1-2): ");
                            int memoryChoice = Convert.ToInt32(Console.ReadLine());
                            PerformMemoryFunction(memoryChoice);
                            break;
                        case 7:
                            DisplayHistoryLog();
                            break;
                        case 8:
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice.\n\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid menu choice.\n\n");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Calculator Menu:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Unit Conversion");
            Console.WriteLine("6. Memory Functions");
            Console.WriteLine("7. View History Log");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice (1-8): ");
        }

        private void PerformCalculation(int choice, double num1, double num2)
        {
            double result = 0;
            string operation = "";

            switch (choice)
            {
                case 1:
                    result = calculator.Add(num1, num2);
                    operation = "+";
                    break;
                case 2:
                    result = calculator.Subtract(num1, num2);
                    operation = "-";
                    break;
                case 3:
                    result = calculator.Multiply(num1, num2);
                    operation = "*";
                    break;
                case 4:
                    try
                    {
                        result = calculator.Divide(num1, num2);
                        operation = "/";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return;
                    }
                    break;
            }

            DisplayResult(result, operation, num1, num2);
            string calculation = $"{num1} {operation} {num2} = {result:F2}";
            calculator.AddToHistoryLog(calculation);
        }

        private void PerformUnitConversion(int choice)
        {
            double result = 0;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter inches: ");
                    double inches = Convert.ToDouble(Console.ReadLine());
                    result = calculator.InchesToCentimeters(inches);
                    Console.WriteLine($"{inches} inches is equal to {result:F2} centimeters.\n\n");
                    break;
                case 2:
                    Console.Write("Enter pounds: ");
                    double pounds = Convert.ToDouble(Console.ReadLine());
                    result = calculator.PoundsToKilograms(pounds);
                    Console.WriteLine($"{pounds} pounds is equal to {result:F2} kilograms.\n\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n\n");
                    break;
            }
        }

        private void PerformMemoryFunction(int choice)
        {
            switch (choice)
            {
                case 1:
                    calculator.StoreInMemory(calculator.RecallFromMemory());
                    Console.WriteLine("Result stored in memory.\n\n");
                    break;
                case 2:
                    double recalledValue = calculator.RecallFromMemory();
                    Console.WriteLine($"Result recalled from memory: {recalledValue}\n\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n\n");
                    break;
            }
        }

        private void DisplayResult(double result, string operation, double num1, double num2)
        {
            Console.WriteLine($"The result of {num1} {operation} {num2} is {result:F2}\n\n");
        }

        private void DisplayHistoryLog()
        {
            Console.WriteLine("History Log:");
            List<string> historyLog = calculator.GetHistoryLog();

            if (historyLog.Count == 0)
            {
                Console.WriteLine("No calculations in the history log.\n\n");
            }
            else
            {
                foreach (string calculation in historyLog)
                {
                    Console.WriteLine(calculation);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}