using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShareApp
{
    internal interface ILocatable
    {
        Location CurrentLocation { get; set; }
    }
}
