using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShareApp
{
    public class InMemoryDatabase
    {
        public List<Rider> Riders { get; set; } = new List<Rider>();
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public List<Ride> Rides { get; set; } = new List<Ride>();
    }
}
