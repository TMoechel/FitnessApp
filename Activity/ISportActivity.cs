namespace FitnessApp.Activity
{
    internal interface ISportActivity
    {
        // Distance in m
        public double Distance { get; set; }

        public string DistanceUnit { get; }

        // Time for Sport Event in hh:mm:ss
        public TimeSpan TimeTaken { get; }

        public DateTime ActivityDate { get; }

        public Feeling Feeling { get; }

        public double CalculateAverageInMPerSecond();

        public double CalculateAverageInKmPerHour();

        public double CalculateAverageSpeed();

        public string GetVelocityUnit();

        public string ShowKmPerHour();

        public string ShowMetersPerSecond();

        public string GetHeartRates();

        public double GetActivityDistance();
    }
}
