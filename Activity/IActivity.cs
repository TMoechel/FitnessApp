namespace FitnessApp.Activity
{
    internal interface ISportActivity
    {
        // Distance in m
        public double Distance { get; }
        
        // Time for Sport Event in hh:mm:ss
        public TimeSpan TimeTaken { get; }

        public DateTime ActivityDate { get; }

        public Feeling Feeling { get; }

        public double CalculateAverageInMPerSecond();

        public double CalculateAverageInKmPerHour();

        public double CalculateAverageSpeed();

        public string ShowKmM();

        public string ShowKmPerHour();

        public string ShowMPerSecond();

        public int HeartRate();
    }
}
