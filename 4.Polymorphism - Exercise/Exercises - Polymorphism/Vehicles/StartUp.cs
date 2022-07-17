using System;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Models;
using Vehicles.IO.Models.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    internal class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            string[] carData = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Vehicle car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
                Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));
                engine = new Engine(reader, writer, car, truck);
                engine.Start();
            }
            catch (ArgumentException ae)
            {
                writer.WriteLine(ae.Message);
            }
            
            
        }
    }
}
