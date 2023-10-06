using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShareApp
{
    class RideService
    {
        private readonly InMemoryDatabase database;

        public RideService(InMemoryDatabase database)
        {
            this.database = database;
        }

        public void RegisterUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            user.Id = database.Riders.Count + database.Drivers.Count + 1;

            if (user is Rider rider)
            {
                database.Riders.Add(rider);
            }
            else if (user is Driver driver)
            {
                database.Drivers.Add(driver);
            }
            else
            {
                throw new ArgumentException("Invalid user type.");
            }
        }

        public void BookRide(Rider rider, Location destination)
        {
            if (rider == null || destination == null)
            {
                throw new ArgumentNullException("Rider and destination must not be null.");
            }

            var driver = FindNearestDriver(destination);

            if (driver == null)
            {
                Console.WriteLine("No available drivers in the area. Ride booking failed.");
                return;
            }

            var ride = new Ride
            {
                Id = database.Rides.Count + 1,
                Rider = rider,
                Driver = driver,
                StartTime = DateTime.Now,
               
            };

            database.Rides.Add(ride);
            rider.RideHistory.Add(ride);
            driver.RideHistory.Add(ride);

            Console.WriteLine($"Ride booked for '{rider.Name}' with driver '{driver.Name}'.");
        }

        public void UpdateCabLocation(Driver driver, Location location)
        {
            if (driver == null || location == null)
            {
                throw new ArgumentNullException("Driver and location must not be null.");
            }

            driver.CurrentLocation = location;
        }

        private bool IsDriverAvailable(Location location)
        {
           
            return database.Drivers.Any(driver => CalculateDistance(driver.CurrentLocation, location) <= 5.0);
        }

        private Driver FindNearestDriver(Location location)
        {
       
            return database.Drivers
                .Where(driver => CalculateDistance(driver.CurrentLocation, location) <= 5.0)
                .OrderBy(driver => CalculateDistance(driver.CurrentLocation, location))
                .FirstOrDefault();
        }

        private double CalculateDistance(Location location1, Location location2)
        {
           
            return Math.Sqrt(Math.Pow(location1.Latitude - location2.Latitude, 2) +
                             Math.Pow(location1.Longitude - location2.Longitude, 2));
        }
    }
}
