using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1VehicleClassHierarchy
{
    public class Motorcycle : Vehicle
    {
        // Motorcycle-specific properties
        public string Type { get; set; }
        public bool HasSidecar { get; set; }

        public Motorcycle(string make, string model, int year, string color, string type, bool hasSidecar)
            : base(make, model, year, color)
        {
            Type = type;
            HasSidecar = hasSidecar;
        }

        // Motorcycle-specific method
        public override void start()
        {
            Console.WriteLine("The Motorcycle is Started.");
        }

        public override void stop()
        {
            Console.WriteLine("The Motorcycle is stoped\n\n");
        }

        public void printMotorcycleDitels()
        {
            Console.WriteLine($"The motorcycle company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, type is {Type}, and {(HasSidecar ? "has a sidecar" : "does not have a sidecar")}.");


        }
    }

}
