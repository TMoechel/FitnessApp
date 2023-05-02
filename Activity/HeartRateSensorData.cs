namespace FitnessApp.Activity
{
    public class SensorData
    {
        public static int SimulateHeartRate(double distance, TimeSpan time, Feeling feeling)
        {
            int baseHeartRate = 60;
            int maxHeartRate = 180;
            int simulatedHeartRate;
            int intensity;

            Random random = new Random();

            switch (feeling)
            {
                case Feeling.Bad:
                    intensity = 40;
                    break;
                case Feeling.Ok:
                    intensity = 60;
                    break;
                case Feeling.Good:
                    intensity = 80;
                    break;
                case Feeling.Strong:
                    intensity = 100;
                    break;
                case Feeling.VeryStrong:
                    intensity = 120;
                    break;
                default:
                    intensity = 50;
                    break;
            }

            //calculate speed
            double speed = distance / (time.Hours * 3600 + time.Minutes * 60 + time.Seconds);
            //calculate factor depending on intensity
            double factor = 1 + (intensity / 100.0) * speed;

            //calculate simHeartRate, multiply factor by a random number
            simulatedHeartRate = baseHeartRate + (int)Math.Round(factor * random.Next(20, 40));

            //heart rate to remain between base and simulated heart rate
            simulatedHeartRate = Math.Min(maxHeartRate, Math.Max(baseHeartRate, simulatedHeartRate));


            return simulatedHeartRate;
        }
    }
}