using NUnit.Framework;
using System.Reflection;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Garage garage;
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GarageConstructor_ShouldCreateGarageAndSetDataCorrectly()
        {
            int capacity = 5;
            garage = new Garage(capacity);

            Assert.IsNotNull(garage);
            Assert.That(garage.Capacity, Is.EqualTo(capacity));
            Assert.IsNotNull(garage.Vehicles);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_VehicleConstructor_ShouldCreateGarageAndSetDataCorrectly()
        {
            string brand = "BMW";
            string model = "i8";
            string number = "Sofia2000";
            double maxMileage = 50;
            vehicle = new Vehicle(brand, model, number, maxMileage);

            Assert.IsNotNull(vehicle);
            Assert.That(vehicle.Brand, Is.EqualTo(brand));
            Assert.That(vehicle.Model, Is.EqualTo(model));
            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo(number));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle.IsDamaged, Is.EqualTo(false));
        }

        [Test]
        public void Test_MethodAddVehicle_ShouldAddVehicle_WhenHaveCapacityAndVehicleNotAdded()
        {
            garage = new Garage(5);
            string brand = "BMW";
            string model = "i8";
            string number = "Sofia2000";
            double maxMileage = 50;
            vehicle = new Vehicle(brand, model, number, maxMileage);

            bool trueOrFalse = garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(garage.Vehicles[0].Brand, Is.EqualTo(brand));
            Assert.That(garage.Vehicles[0].Model, Is.EqualTo(model));
            Assert.That(garage.Vehicles[0].LicensePlateNumber, Is.EqualTo(number));
            Assert.That(garage.Vehicles[0].BatteryLevel, Is.EqualTo(100));
            Assert.That(garage.Vehicles[0].IsDamaged, Is.EqualTo(false));
            Assert.IsTrue(trueOrFalse);
        }

        [Test]
        public void Test_MethodAddVehicle_ShouldReturnFalse_WhenDontHaveCapacity()
        {
            garage = new Garage(0);
            string brand = "BMW";
            string model = "i8";
            string number = "Sofia2000";
            double maxMileage = 50;
            vehicle = new Vehicle(brand, model, number, maxMileage);

            bool trueOrFalse = garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
            Assert.IsFalse(trueOrFalse);
        }

        [Test]
        public void Test_MethodAddVehicle_ShouldReturnFalse_WhenVehicleIsAlreadyAdded()
        {
            garage = new Garage(5);
            string brand = "BMW";
            string model = "i8";
            string number = "Sofia2000";
            double maxMileage = 50;
            vehicle = new Vehicle(brand, model, number, maxMileage);
            garage.AddVehicle(vehicle);
            bool trueOrFalse = garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.IsFalse(trueOrFalse);
        }

        [Test]
        public void Test_MethodDrive_ShouldDecreaseBatteryLevel_WhenVehicleDontDamagedAndHaveBatteryForDriving()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia3", 50, false);

            Assert.That(garage.Vehicles[2].BatteryLevel, Is.EqualTo(50));
            Assert.That(garage.Vehicles[2].IsDamaged, Is.EqualTo(false));

            garage.DriveVehicle("Sofia2", 70, true);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(30));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(true));
        }

        [Test]
        public void Test_MethodDrive_ShouldDecreaseBatteryLevel_WhenVehicleIsDamagedIsTrue()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia2", 20, true);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(80));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(true));

            garage.DriveVehicle("Sofia2", 20, false);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(80));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(true));
        }

        [Test]
        public void Test_MethodDrive_ShouldDecreaseBatteryLevel_WhenDontHaveEnoughBattery()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia2", 70, false);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(30));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(false));

            garage.DriveVehicle("Sofia2", 50, true);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(30));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(false));
        }

        [Test]
        public void Test_MethodDrive_ShouldDecreaseBatteryLevel_WhenBatteryDrainIsMoreThanBatteryLevel()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia2", 150, true);

            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(100));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(false));
        }

        [Test]
        public void Test_MethodChargeVehicles_ShouldChargeVehicles_WhenVehicleHaveLessBatteryLevel()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia1", 10, false);
            Assert.That(garage.Vehicles[0].BatteryLevel, Is.EqualTo(90));
            garage.DriveVehicle("Sofia2", 60, false);
            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(40));
            garage.DriveVehicle("Sofia3", 70, false);
            Assert.That(garage.Vehicles[2].BatteryLevel, Is.EqualTo(30));
            garage.DriveVehicle("Sofia4", 20, false);
            Assert.That(garage.Vehicles[3].BatteryLevel, Is.EqualTo(80));

            int vehiclesCharged = garage.ChargeVehicles(50);
            Assert.That(garage.Vehicles[0].BatteryLevel, Is.EqualTo(90));
            Assert.That(garage.Vehicles[1].BatteryLevel, Is.EqualTo(100));
            Assert.That(garage.Vehicles[2].BatteryLevel, Is.EqualTo(100));
            Assert.That(garage.Vehicles[3].BatteryLevel, Is.EqualTo(80));
            Assert.That(vehiclesCharged, Is.EqualTo(2));

        }

        [Test]
        public void Test_MethodRepairVehicles_MustRepairAllVehicleWithIsDamagePropertyEqualToTrue()
        {
            garage = new Garage(5);
            vehicle = new Vehicle("BMW1", "i81", "Sofia1", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW2", "i82", "Sofia2", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW3", "i83", "Sofia3", 50);
            garage.AddVehicle(vehicle);
            vehicle = new Vehicle("BMW4", "i84", "Sofia4", 50);
            garage.AddVehicle(vehicle);

            garage.DriveVehicle("Sofia1", 10, true);
            Assert.That(garage.Vehicles[0].IsDamaged, Is.EqualTo(true));
            garage.DriveVehicle("Sofia2", 60, false);
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(false));
            garage.DriveVehicle("Sofia3", 70, true);
            Assert.That(garage.Vehicles[2].IsDamaged, Is.EqualTo(true));
            garage.DriveVehicle("Sofia4", 20, true);
            Assert.That(garage.Vehicles[3].IsDamaged, Is.EqualTo(true));

            string realVehiclesRepaired = garage.RepairVehicles();
            string expectedVehiclesRepaired = "Vehicles repaired: 3";

            Assert.That(garage.Vehicles[0].IsDamaged, Is.EqualTo(false));
            Assert.That(garage.Vehicles[1].IsDamaged, Is.EqualTo(false));
            Assert.That(garage.Vehicles[2].IsDamaged, Is.EqualTo(false));
            Assert.That(garage.Vehicles[3].IsDamaged, Is.EqualTo(false));
            Assert.That(realVehiclesRepaired, Is.EqualTo(expectedVehiclesRepaired));
        }
    }
}