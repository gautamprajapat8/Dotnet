using Level1VehicleClassHierarchy;
using Level2AbstractClassOrInterface;
using System;

public class Motorcycle : Vehicle, IVehicleOperations
{
    public string Type { get; set; }
    public bool HasSidecar { get; set; }

    public Motorcycle(string make, string model, int year, string color, string type, bool hasSidecar)
        : base(make, model, year, color)
    {
        Type = type;
        HasSidecar = hasSidecar;
    }

    public override void start()
    {
        Console.WriteLine("The Motorcycle is Started.");
    }

    public override void stop()
    {
        Console.WriteLine("The Motorcycle is stopped\n\n");
    }

    public void printMotorcycleDetails()
    {
        Console.WriteLine($"The motorcycle company is {base.Make}, model is {base.Model}, color is {base.Color}, built in {base.Year}, type is {Type}, and {(HasSidecar ? "has a sidecar" : "does not have a sidecar")}.");
    }

    public void CalculateFuelEfficiency()
    {
        Console.WriteLine("Calculating motorcycle fuel efficiency...");
        // Implement motorcycle-specific fuel efficiency calculation here
    }

    public void StartEngine()
    {
        Console.WriteLine("Starting motorcycle engine...");
        // Implement motorcycle-specific engine start here
    }
}
