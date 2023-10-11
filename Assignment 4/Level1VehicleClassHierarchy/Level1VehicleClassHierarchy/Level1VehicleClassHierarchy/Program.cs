using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1VehicleClassHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car mycar=new Car(4,"petrol",2023, "red", "Tata", "nexan");


            mycar.start();
            mycar.printCarDitels();
            mycar.stop();


            Motorcycle myBike = new Motorcycle("TVS", "rider", 2022, "black", "Sports", false);

            myBike.start();
            myBike.printMotorcycleDitels();
            myBike.stop();

            Bicycle myBicycle = new Bicycle("Atlas", "2001", 1998, "pink", 6, "steel and Iron");

            myBicycle.start();
            myBicycle.printBicycleDitels();
            myBicycle.stop();
        }
    }
}
