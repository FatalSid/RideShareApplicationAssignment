namespace RideShareApp
{
    public class Ride
    {
        public int Id { get; set; }
        public Rider Rider { get; set; }
        public Driver Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}