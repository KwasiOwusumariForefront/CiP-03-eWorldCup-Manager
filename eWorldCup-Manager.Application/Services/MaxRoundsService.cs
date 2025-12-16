namespace eWorldCup_Manager.Applications.Services
{
    public class MaxRoundsService
    {
        public static long CalculateMaxRounds(long players)
        {
            return players - 1;
        }

    }
}
