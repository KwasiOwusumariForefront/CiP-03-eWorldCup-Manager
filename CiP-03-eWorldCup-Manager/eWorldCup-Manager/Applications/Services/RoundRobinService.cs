using Core.Interfaces;

namespace eWorldCup_Manager.Applications.Services
{
    public class RoundRobinService
    {
        // Returns a list of pairs for a given round
        public static List<(Player Home, Player Away)> GetRoundPairs(List<Player> players, int roundNum)
        {
            int numPlayers = players.Count;
            if (numPlayers < 2 || numPlayers % 2 != 0)
                return new List<(Player, Player)>(); // or throw exception

            int rounds = numPlayers - 1;
            int half = numPlayers / 2;
            var rotation = new List<Player>(players);
            List<(Player, Player)> pairsForRound = new List<(Player, Player)>();

            for (int round = 0; round < rounds; ++round)
            {
                var matches = new List<(Player, Player)>();
                for (int i = 0; i < half; ++i)
                    matches.Add((rotation[i], rotation[numPlayers - 1 - i]));

                if (round + 1 == roundNum)
                {
                    pairsForRound = matches;
                    break;
                }

                // rotate (except first)
                var last = rotation[numPlayers - 1];
                for (int i = numPlayers - 1; i > 1; --i)
                    rotation[i] = rotation[i - 1];
                rotation[1] = last;
            }

            return pairsForRound;
        }
    }
}
