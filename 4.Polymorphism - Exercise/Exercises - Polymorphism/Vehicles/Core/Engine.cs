using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Models.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine()
        {

        }
        public Engine(IReader reader, IWriter writer, Vehicle car, Vehicle truck, Vehicle bus) : base()
        {
            this.writer = writer;
            this.reader = reader;
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }
        public void Start()
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                try
                {
                    if (command == "Drive")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        if (vehicleType == "Car")
                        {
                            writer.WriteLine(car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            writer.WriteLine(truck.Drive(distance));
                        }
                        else if (vehicleType == "Bus")
                        {
                            writer.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double fuelToRefuel = double.Parse(cmdArgs[2]);
                        if (vehicleType == "Car")
                        {
                            car.Refuel(fuelToRefuel);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(fuelToRefuel);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(fuelToRefuel);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        Bus bus1 = bus as Bus;
                        writer.WriteLine(bus1.DriveEmpty(distance));
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }
    }
}
