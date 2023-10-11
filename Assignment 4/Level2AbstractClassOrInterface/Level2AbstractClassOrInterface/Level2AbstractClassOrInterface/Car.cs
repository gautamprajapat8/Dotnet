using Level1VehicleClassHierarchy;
using Level2AbstractClassOrInterface;
using System;

public class Car : Vehicle, IVehicleOperations
{
    public int NumberOfDoors { get; set; }
    public string FuelType { get; set; }

    public Car(int numberOfDoors, string fuelType, int year, string color, string make, string model)
        : base(make, model, year, color)
    {
        NumberOfDoors = numberOfDoors;
        FuelType = fuelType;
    }

    public override void start()
    {
        Console.WriteLine("The car is Started.");
    }

    public override void stop()
    {
        Console.WriteLine("The car is stopped\n\n");
    }

    public void printCarDetails()
    {
        Console.WriteLine($"The car company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, has {NumberOfDoors} doors, and its fuel type is {FuelType}.");
    }

    public void CalculateFuelEfficiency()
    {
        Console.WriteLine("Calculating car fuel efficiency...");
        // Implement car-specific fuel efficiency calculation here
    }

    public void StartEngine()
    {
        Console.WriteLine("Starting car engine...");
        // Implement car-specific engine start here
    }
}
