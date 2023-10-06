using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShareApp
{
    public class Rider: IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Other rider properties like email, phone, etc.

        public List<Ride> RideHistory { get; set; } = new List<Ride>();
    }
}
