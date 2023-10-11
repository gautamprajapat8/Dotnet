using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1VehicleClassHierarchy
{
    public class Bicycle : Vehicle
    {
        // Bicycle-specific properties
        public int NumberOfGears { get; set; }
        public string FrameMaterial { get; set; }

        public Bicycle(string make, string model, int year, string color, int numberOfGears, string frameMaterial)
            : base(make, model, year, color)
        {
            NumberOfGears = numberOfGears;
            FrameMaterial = frameMaterial;
        }

        // Bicycle-specific method

        public override void start()
        {
            Console.WriteLine("The bicycle is being pedaled.");
        }

        public override void stop()
        {
            Console.WriteLine("The bicycle is stoped\n\n");
        }

        public void printBicycleDitels()
        {
            Console.WriteLine($"The bicycle company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, has {NumberOfGears} Gears, and its frame Material is {FrameMaterial}.");

        }

    }

}
