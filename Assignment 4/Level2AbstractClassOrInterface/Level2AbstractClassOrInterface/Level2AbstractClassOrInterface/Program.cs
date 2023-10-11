using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level2AbstractClassOrInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(4, "Petrol", 2023, "Red", "Tata", "Nexan");
            Bicycle myBicycle = new Bicycle("Atlas", "2001", 1998, "Pink", 6, "Steel and Iron");
            Motorcycle myMotorcycle = new Motorcycle("TVS", "Rider", 2022, "Black", "Sports", false);

            List<IVehicleOperations> vehicles = new List<IVehicleOperations> { myCar, myBicycle, myMotorcycle };

            foreach (var vehicle in vehicles)
            {
                vehicle.CalculateFuelEfficiency();
                vehicle.StartEngine();
                Console.WriteLine(); // Add a line break for readability
            }


            myCar.start();
            myCar.printCarDetails();
            myCar.stop();


            myMotorcycle.start();
            myMotorcycle.printMotorcycleDetails();
            myMotorcycle.stop();


            myBicycle.start();
            myBicycle.printBicycleDetails();
            myBicycle.stop();





        }
    }
}
