using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level2LINQAndCollectionManipulation
{

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Step 1: Data Collection
            List<Student> students = new List<Student>
        {
            new Student { Name = "gautam", Age = 20, Grade = 85.5 },
            new Student { Name = "gita", Age = 22, Grade = 92.0 },
            new Student { Name = "Deepu", Age = 21, Grade = 75.5 },
            new Student { Name = "Brajesh", Age = 23, Grade = 88.0 }
        };

            // Step 2: LINQ Queries
            var highScorers = students.Where(s => s.Grade >= 90);
            var averageAge = students.Average(s => s.Age);

            // Step 3: Data Manipulation
            var orderedStudents = students.OrderBy(s => s.Name);
            var groupedByAge = students.GroupBy(s => s.Age);

            // Step 4: Output
            Console.WriteLine("High Scorers:");
            foreach (var student in highScorers)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            }

            Console.WriteLine("\nAverage Age: " + averageAge);

            Console.WriteLine("\nOrdered Students:");

            foreach (var student in orderedStudents)
            {
                Console.WriteLine($"Name: {student.Name}");
            }

            Console.WriteLine("\nStudents Grouped by Age:");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"Name: {student.Name}");
                }
            }
        }
        
    }
}
