namespace RideShareApp
{
    public class Location
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value < -90.0 || value > 90.0)
                {
                    throw new ArgumentException("Latitude must be between -90 and 90 degrees.");
                }
                latitude = value;
            }
        }

        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value < -180.0 || value > 180.0)
                {
                    throw new ArgumentException("Longitude must be between -180 and 180 degrees.");
                }
                longitude = value;
            }
        }
    }

}