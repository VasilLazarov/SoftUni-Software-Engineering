using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly UserRepository users;
        private readonly VehicleRepository vehicles;
        private readonly RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            if (users.GetAll().Any(u => u.DrivingLicenseNumber == drivingLicenseNumber))
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if(vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            IVehicle vehicle = null;
            if(vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            if (vehicles.GetAll().Any(u => u.LicensePlateNumber == licensePlateNumber))
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
        
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            if(routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            else if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            IRoute routeForLock = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);
            if(routeForLock != null)
            {
                routeForLock.LockRoute();
            }

            routes.AddModel(route);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if(user.IsBlocked == true)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if(vehicle.IsDamaged == true)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            if(route.IsLocked == true)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }
            vehicle.Drive(route.Length);
            if(isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }


        public string RepairVehicles(int count)
        {
            List<IVehicle> validVehicles = vehicles.GetAll()
                .Where(r => r.IsDamaged == true)
                .OrderBy(r => r.Brand)
                .ThenBy(r => r.Model)
                .ToList();
            if(validVehicles.Count < count)
            {
                count = validVehicles.Count;
            }

            IVehicle vehicle;
            for (int i = 0; i < count; i++)
            {
                vehicle = validVehicles[i];
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, count);
        }


        public string UsersReport()
        {
            List<IUser> orderedUsers = users.GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();
            StringBuilder result = new StringBuilder();
            result.AppendLine("*** E-Drive-Rent ***");
            foreach(IUser user in orderedUsers)
            {
                result.AppendLine(user.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
