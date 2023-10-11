using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1VehicleClassHierarchy
{

    public class Car:Vehicle
    {
        public int NumberOfDoors { get; set; }
        public String FuelType { get; set; }

        public Car(int numberOfDoors, String fuelType, int year, String color, String make, String model)
            : base(make, model, year, color)
        {
            NumberOfDoors=numberOfDoors;
            FuelType = fuelType;
        }

       
        public override void start()
        {
            Console.WriteLine("The car is Started.");
        }

        public override void stop() 
        { 
            Console.WriteLine("The car is stoped\n\n");
        }

        public void printCarDitels()
        {
            Console.WriteLine($"The car company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, has {NumberOfDoors} doors, and its fuel type is {FuelType}.");

        }

    }

}
