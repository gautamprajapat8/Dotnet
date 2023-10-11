using Level1VehicleClassHierarchy;
using Level2AbstractClassOrInterface;
using System;

public class Bicycle : Vehicle, IVehicleOperations
{
    public int NumberOfGears { get; set; }
    public string FrameMaterial { get; set; }

    public Bicycle(string make, string model, int year, string color, int numberOfGears, string frameMaterial)
        : base(make, model, year, color)
    {
        NumberOfGears = numberOfGears;
        FrameMaterial = frameMaterial;
    }

    public override void start()
    {
        Console.WriteLine("The bicycle is being pedaled.");
    }

    public override void stop()
    {
        Console.WriteLine("The bicycle is stopped\n\n");
    }

    public void printBicycleDetails()
    {
        Console.WriteLine($"The bicycle company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, has {NumberOfGears} gears, and its frame material is {FrameMaterial}.");
    }

    public void CalculateFuelEfficiency()
    {
        Console.WriteLine("Bicycles do not use fuel.");
    }

    public void StartEngine()
    {
        Console.WriteLine("Bicycles do not have engines.");
    }
}
