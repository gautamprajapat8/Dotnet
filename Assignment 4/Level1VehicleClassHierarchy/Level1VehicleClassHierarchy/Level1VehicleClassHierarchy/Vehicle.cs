using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1VehicleClassHierarchy
{
    public class Vehicle
    {
        // comman proparty
        public String Make {  get; set; }
        public String Model { get; set; }
        public int Year { get; set; }
        public String Color { get; set; }


        public Vehicle(string make, string model, int year, string color )
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }
        public virtual void start()
        {
            Console.WriteLine("The vehicle has started.");
        }

        public virtual void stop() 
        {
            Console.WriteLine("The vehicle has stoped.");
        }
    }
}
