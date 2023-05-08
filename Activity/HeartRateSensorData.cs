namespace FitnessApp.Activity
{
    public class SensorData
    {
        public static int[] SimulateHeartRates(Feeling feeling)
        {
            int heartRateLevelBad = 160;
            int heartRateLevelOk = 150;
            int heartRateLevelGood = 140;
            int heartRateLevelStrong = 130;
            int heartRateLevelVeryStrong = 120;

            int[] result;

            switch (feeling)
            {
                case Feeling.Bad:
                    result = GenerateRandomInts(heartRateLevelBad);
                    break;
                case Feeling.Ok:
                    result = GenerateRandomInts(heartRateLevelOk);
                    break;
                case Feeling.Good:
                    result = GenerateRandomInts(heartRateLevelGood);
                    break;
                case Feeling.Strong:
                    result = GenerateRandomInts(heartRateLevelStrong);
                    break;
                case Feeling.VeryStrong:
                    result = GenerateRandomInts(heartRateLevelVeryStrong);
                    break;
                default:
                    result = new int[10];
                    break;
            }
            return result;
        }

        private static int[] GenerateRandomInts(int heartRateLevel)
        {
            int[] result = new int[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                result[i] = heartRateLevel + random.Next(0, 20);
            }
            return result;
        }
    }
}