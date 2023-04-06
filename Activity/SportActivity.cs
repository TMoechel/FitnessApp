using FitnessApp.Data;
using FitnessApp.UI;

namespace FitnessApp.Activity
{
    public class SportActivity : ISportActivity
    {
        private double _distance;
        
        /// <summary>
        /// Distance in m
        /// </summary>
        public double Distance
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

        public DateTime Date { get; }

        private Feeling _feeling;
        public Feeling Feeling
        {
            get { return _feeling; }
            set { _feeling = value; }
        }

        public SportActivity(double distance, TimeSpan timeTaken, Feeling feeling)
        {
            Distance = distance;
            TimeTaken = timeTaken;
            Feeling = feeling;
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

        public virtual string ShowKmM()
        {
            return ShowKmPerHour();
        }

        public string ShowKmPerHour()
        {
            return "Km/h";
        }

        public string ShowMPerSecond()
        {
            return "m/s";
        }
    }
}