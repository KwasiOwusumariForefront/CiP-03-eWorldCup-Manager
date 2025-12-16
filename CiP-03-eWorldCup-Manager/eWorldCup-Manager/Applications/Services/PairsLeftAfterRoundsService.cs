using Core.Interfaces;
using eWorldCup_Manager.Models;

namespace eWorldCup_Manager.Applications.Services
{
    public class PairsLeftAfterRoundsService
    {
        public static long CalculatePairsLeftAfterRounds(long Players, long Rounds)
        {
            long maxRounds = Players - 1;
            long totalPairs = Players / 2 * maxRounds;
            long playedPairs = Players / 2 * Rounds;
            return totalPairs - playedPairs;
        }
    }
}
