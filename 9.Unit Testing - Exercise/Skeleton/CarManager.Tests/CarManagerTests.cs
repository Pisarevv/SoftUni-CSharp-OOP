namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        //TestConstructor
        [TestCase(new object[] {"VW", "Passat", 6.8, 70.0 })]
        public void ConstructorShoudCreateACarWithValidFieldsAndFuelAmoutEquivalentToZero(object[] parameters)
        {
            //Assign
            Car car =new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            //Act
            Type type = car.GetType();
            FieldInfo[] properties = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            //Assert
            string expectedMake = (string)parameters[0];
            string expctedModel = (string)parameters[1];
            double expectedFuelConsumption = (double)parameters[2];
            double expectedFuelAmount = 0;
            double expectedFuelCapacity = (double)parameters[3];

            string actualMake = properties[0].GetValue(car).ToString();
            string actualModel = properties[1].GetValue(car).ToString();
            double actualFuelConsumption = double.Parse(properties[2].GetValue(car).ToString());
            double actualFuelAmout= double.Parse(properties[3].GetValue(car).ToString());
            double actualFuelCapacity = double.Parse(properties[4].GetValue(car).ToString());

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expctedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelAmount, actualFuelAmout);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);

        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void MakePropertyShoudSetAndReturnCarMakeWhenCarMakeIsNotNullOrEmpty(object[] parameters)
        {
            //Assign && Act
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            string expectedMake = (string)parameters[0];
            string actualMake = car.Make;
            //Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(new object[] { "", "Passat", 6.8, 70.0 })]
        [TestCase(new object[] { null, "Passat", 6.8, 70.0 })]
        public void MakePropertyShouldThrowArgumentExceptionWhenInputIsNullOrEmpty(object[] parameters)
        {
            //Assign, Act,Assert    
            Assert.That(() =>
            {
                Car car = new Car
                                (
                                  (string)parameters[0],
                                  (string)parameters[1],
                                  (double)parameters[2],
                                  (double)parameters[3]
                                );
            },Throws.TypeOf<ArgumentException>(), "Make cannot be null or empty!");
            
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void ModelPropertyShoudSetAndReturnCarMakeWhenModelIsNotNullOrEmpty(object[] parameters)
        {
            //Assign && Act
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            string expectedModel = (string)parameters[1];
            string actualModel = car.Model;
            //Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(new object[] { "VW", "", 6.8, 70.0 })]
        [TestCase(new object[] { "VW", null, 6.8, 70.0 })]
        public void ModelPropertyShouldThrowArgumentExceptionWhenInputIsNullOrEmpty(object[] parameters)
        {
            //Assign, Act,Assert    
            Assert.That(() =>
            {
                Car car = new Car
                                (
                                  (string)parameters[0],
                                  (string)parameters[1],
                                  (double)parameters[2],
                                  (double)parameters[3]
                                );
            }, Throws.TypeOf<ArgumentException>(), "Model cannot be null or empty!");

        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void FuelConsumptionPropertyShoudSetAndReturnCarFuelConsimptionWhenCarCarConsumptionIsPositive(object[] parameters)
        {
            //Assign && Act
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            double expectedFuelConsumption = (double)parameters[2];
            double actualFuelConsumption = car.FuelConsumption;
            //Assert
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase(new object[] { "VW", "Passat", 0.0, 70.0 })]
        [TestCase(new object[] { "VW", "Passat", -1.5, 70.0 })]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenInputIsNegativeOrZero(object[] parameters)
        {
            //Assign, Act,Assert    
            Assert.That(() =>
            {
                Car car = new Car
                                (
                                  (string)parameters[0],
                                  (string)parameters[1],
                                  (double)parameters[2],
                                  (double)parameters[3]
                                );
            }, Throws.TypeOf<ArgumentException>(), "Fuel consumption cannot be zero or negative!");

        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void FuelCapacityPropertyShoudSetAndReturnCarFuelCapacityWhenCarFuelCapacitiIsPositive(object[] parameters)
        {
            //Assign && Act
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            double expectedFuelCapacity = (double)parameters[3];
            double actualFuelConsumption = car.FuelCapacity;
            //Assert
            Assert.AreEqual(expectedFuelCapacity, actualFuelConsumption);
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 0.0 })]
        [TestCase(new object[] { "VW", "Passat", 6.8, -1.23})]
        public void FuelCapacityShouldThrowArgumentExceptionWhenInputIsNegativeOrZero(object[] parameters)
        {
            //Assign, Act,Assert    
            Assert.That(() =>
            {
                Car car = new Car
                                (
                                  (string)parameters[0],
                                  (string)parameters[1],
                                  (double)parameters[2],
                                  (double)parameters[3]
                                );
            }, Throws.TypeOf<ArgumentException>(), "Fuel capacity cannot be zero or negative!");

        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void FuelAmoutPropertyShoudSetAndReturnCarFuelAmoutWhenCarIsInitializedViaConstructor(object[] parameters)
        {
            //Assign && Act
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            double expectedFuelAmout = 0;
            double actualFuelAmout = car.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuelAmout, actualFuelAmout);
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void RefuelMethodShoudRefuelCar(object[] parameters)
        {
            //Assign 
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            //Act
            car.Refuel(10);
            //Assert
            double expectedFuelAmout = 10;
            double actualFuelAmout = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmout, actualFuelAmout);
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void RefuelMethodShoudThrowArgumentExceptionWhenRefuelValueIsNegative(object[] parameters)
        {
            //Assign 
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            //Act && Assert
            Assert.That(() =>
            {
                car.Refuel(-1.5);
            }
            , Throws.TypeOf<ArgumentException>(), "Fuel amount cannot be zero or negative!");
            
        }
        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void RefuelMethodShoudThrowArgumentExceptionWhenRefuelValueIsZero(object[] parameters)
        {
            //Assign 
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            //Act && Assert
            Assert.That(() =>
            {
                car.Refuel(0);
            }
            , Throws.TypeOf<ArgumentException>(), "Fuel amount cannot be zero or negative!");

        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void RefuelMethodShoudRefuelCarToFuelCapacityIfRefuelValueIsOverThatCapacity(object[] parameters)
        {
            //Assign 
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            //Act
            car.Refuel(100);
            //Assert
            double expectedFuelAmout = car.FuelCapacity;
            double actualFuelAmout = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmout, actualFuelAmout);
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void DriveMethodShoudDriveCarWhenNeededFuelIsEqualOrLessThanFuelAmount(object[] parameters)
        {
            //Assign 
            double fuelToRefuel = 70;
            double distanceToDrive = 10;
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            double fuelConsumption = (double)parameters[2];
            //Act
            car.Refuel(fuelToRefuel);
            car.Drive(distanceToDrive);
            //Assert
            double expectedFuelAmoutLeft = fuelToRefuel - ((distanceToDrive / 100) * fuelConsumption);
            double actualFuelAmoutLeft = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmoutLeft, actualFuelAmoutLeft);
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void DriveMethodShoudThrowInvalidOperationExceptionWhenNeededMoreThanFuelAmount(object[] parameters)
        {
            //Assign 
            double distanceToDrive = 10000;
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );
            Assert.That(() =>
            {
                car.Drive(distanceToDrive);
            }
            , Throws.TypeOf<InvalidOperationException>(), "You don't have enough fuel to drive!");
        }

        [TestCase(new object[] { "VW", "Passat", 6.8, 70.0 })]
        public void FuelAmountPropertyShouldThrowArgumentExceptionWhenTryingToSetItBelowZero(object[] parameters)
        {
            //Assign 
            Car car = new Car
                (
                  (string)parameters[0],
                  (string)parameters[1],
                  (double)parameters[2],
                  (double)parameters[3]
                );

            Type type = car.GetType();
            PropertyInfo fuelAmountProperty = 
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.Name == "FuelAmount").FirstOrDefault();
            Assert.That(() =>
            {
                fuelAmountProperty.SetValue(car, -5);
            }
            , Throws.Exception, "Fuel amount cannot be negative!");
        }


    }
}


    