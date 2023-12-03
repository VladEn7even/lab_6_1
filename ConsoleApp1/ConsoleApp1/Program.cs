using System;
using System.Collections.Generic;

// Абстрактний клас для транспортного засобу
public abstract class Vehicle
{
    public double Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

// Клас для людини
public class Human
{
    public double Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving");
    }
}

// Класи для різних видів транспорту
public class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving");
    }
}

public class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving");
    }
}

public class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving");
    }
}

// Клас для мережі транспорту
public class TransportNetwork
{
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.Move();
        }
    }
}

// Клас для маршруту
public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
}

// Розширена логіка посадки та висадки пасажирів
public interface IPassengerTransport
{
    void BoardPassengers();
    void DisembarkPassengers();
}

public class BusWithRoute : Bus, IPassengerTransport
{
    public Route CurrentRoute { get; set; }

    public BusWithRoute(Route route)
    {
        CurrentRoute = route;
    }

    public void BoardPassengers()
    {
        Console.WriteLine($"Passengers boarding the bus for the route from {CurrentRoute.StartPoint} to {CurrentRoute.EndPoint}");
    }

    public void DisembarkPassengers()
    {
        Console.WriteLine($"Passengers disembarking the bus at {CurrentRoute.EndPoint}");
    }
}

class Program
{
    static void Main()
    {
        var car = new Car();
        var bus = new BusWithRoute(new Route("A", "B"));
        var train = new Train();

        var transportNetwork = new TransportNetwork();
        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.ControlMovement();

        if (bus is IPassengerTransport passengerTransport)
        {
            passengerTransport.BoardPassengers();
            passengerTransport.DisembarkPassengers();
        }
    }
}
