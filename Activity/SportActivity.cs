namespace FitnessApp.Activity
{
    public class SportActivity : ISportActivity
    {
        
        private double _distance;
        
        /// <summary>
        /// Distance in m
        /// </summary>
        public virtual double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        private TimeSpan _timeTaken;
        
        /// <summary>
        /// TimeTaken in hh:mm:ss
        /// </summary>
        public TimeSpan TimeTaken
        {
            get { return _timeTaken; }
            set { _timeTaken = value; }
        }

        private DateTime _activityDate;

        public DateTime ActivityDate
        {
            get { return _activityDate; }
            set { _activityDate = value; }
        }

        private Feeling _feeling;
        public Feeling Feeling
        {
            get { return _feeling; }
            set { _feeling = value; }
        }

        // set a default Name to empty string
        // descendant classes will override this value with the proper value for the activity
        public virtual string ActivityName => "";

        public virtual string DistanceUnit => "";

        public SportActivity(DateTime activityDate, double distance, TimeSpan timeTaken, Feeling feeling)
        {
            ActivityDate = activityDate;
            Distance = distance;
            TimeTaken = timeTaken;
            Feeling = feeling;
        }
        
        public string GetHeartRates()
        {
            int[] simulatedHeartRates = SensorData.SimulateHeartRates(Feeling);
            return string.Join(" ", simulatedHeartRates); ;
        }

        public double CalculateAverageInMPerSecond()
        {
            var averageInMPerSecond = Distance / (TimeTaken.Hours * 3600 + TimeTaken.Minutes * 60 + TimeTaken.Seconds);
            return Math.Round(averageInMPerSecond, 2);
        }

        public double CalculateAverageInKmPerHour()
        {
            
            var averageInKmPerHour = (Distance / 1000) / (TimeTaken.Hours + (TimeTaken.Minutes / 60f) + (TimeTaken.Seconds / 3600f));
            return Math.Round(averageInKmPerHour, 2);
        }

        public virtual double CalculateAverageSpeed() 
        {
            return CalculateAverageInKmPerHour();
        }

        // default is "Km/h" for base class
        public virtual string GetVelocityUnit()
        {
            return ShowKmPerHour();
        }

        public string ShowKmPerHour()
        {
            return "Km/h";
        }

        public string ShowMetersPerSecond()
        {
            return "m/s";
        }

        // distance in m for base class
        public virtual double GetActivityDistance()
        {
            return _distance;
        }
    }
}