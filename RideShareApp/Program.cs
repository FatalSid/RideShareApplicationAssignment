using RideShareApp;

using System;

class Program
{
    static void Main(string[] args)
    {
        var database = new InMemoryDatabase();
        var rideService = new RideService(database);

        while (true)
        {
            Console.WriteLine("RideShare App Menu:");
            Console.WriteLine("1. Register Rider");
            Console.WriteLine("2. Register Driver");
            Console.WriteLine("3. Update Cab Location");
            Console.WriteLine("4. Book a Ride");
            Console.WriteLine("5. Show Ride History");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Rider Name: ");
                    string riderName = Console.ReadLine();
                    var rider = new Rider { Name = riderName };
                    rideService.RegisterUser(rider);
                    Console.WriteLine($"Rider '{riderName}' registered successfully.");
                    break;

                case "2":
                    Console.Write("Enter Driver Name: ");
                    string driverName = Console.ReadLine();
                    var driver = new Driver { Name = driverName };
                    rideService.RegisterUser(driver);
                    Console.WriteLine($"Driver '{driverName}' registered successfully.");
                    break;

                case "3":
                    Console.Write("Enter Driver Name: ");
                    string driverNameForLocation = Console.ReadLine();
                    var selectedDriver = database.Drivers.Find(d => d.Name == driverNameForLocation);

                    if (selectedDriver == null)
                    {
                        Console.WriteLine($"Driver '{driverNameForLocation}' not found.");
                        break;
                    }

                    Console.Write("Enter Current Latitude: ");
                    if (double.TryParse(Console.ReadLine(), out double currentLatitude))
                    {
                        Console.Write("Enter Current Longitude: ");
                        if (double.TryParse(Console.ReadLine(), out double currentLongitude))
                        {
                            var location = new Location { Latitude = currentLatitude, Longitude = currentLongitude };
                            rideService.UpdateCabLocation(selectedDriver, location);
                            Console.WriteLine($"Location updated for '{driverNameForLocation}'.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid longitude format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid latitude format.");
                    }
                    break;

                case "4":
                    Console.Write("Enter Rider Name: ");
                    string riderNameForBooking = Console.ReadLine();
                    var selectedRider = database.Riders.Find(r => r.Name == riderNameForBooking);

                    if (selectedRider == null)
                    {
                        Console.WriteLine($"Rider '{riderNameForBooking}' not found.");
                        break;
                    }

                    Console.Write("Enter Destination Latitude: ");
                    if (double.TryParse(Console.ReadLine(), out double destinationLatitude))
                    {
                        Console.Write("Enter Destination Longitude: ");
                        if (double.TryParse(Console.ReadLine(), out double destinationLongitude))
                        {
                            var destination = new Location { Latitude = destinationLatitude, Longitude = destinationLongitude };
                            rideService.BookRide(selectedRider, destination);
                            Console.WriteLine($"Ride booked for '{riderNameForBooking}'.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid longitude format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid latitude format.");
                    }
                    break;

                case "5":
                    Console.Write("Enter Rider Name: ");
                    string riderNameForHistory = Console.ReadLine();
                    var riderHistory = database.Riders.Find(r => r.Name == riderNameForHistory);

                    if (riderHistory == null)
                    {
                        Console.WriteLine($"Rider '{riderNameForHistory}' not found.");
                        break;
                    }

                    Console.WriteLine($"Ride History for '{riderNameForHistory}':");
                    foreach (var ride in riderHistory.RideHistory)
                    {
                        Console.WriteLine($"Ride ID: {ride.Id}, Driver: {ride.Driver.Name}, Date: {ride.StartTime}");
                    }
                    break;

                

                case "6":
                    Console.WriteLine("Exiting the application.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-6).");
                    break;
            }
        }
    }
}




