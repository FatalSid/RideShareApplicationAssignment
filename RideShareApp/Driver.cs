namespace RideShareApp
{
    public class Driver : IUser, ILocatable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Location CurrentLocation { get; set; }
        public List<Ride> RideHistory { get; set; } = new List<Ride>();
    }
}