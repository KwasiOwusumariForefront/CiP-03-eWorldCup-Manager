using Core.Interfaces;

namespace eWorldCup_Manager.Applications.Services
{
    public class RoundRobinService2
    {
        public static List<(int Round, Player Opponent, bool IsHome)> GetPlayerRounds(List<Player> players, int playerIndex)
        {
            int numPlayers = players.Count;
            if (numPlayers < 2 || numPlayers % 2 != 0)
                return new List<(int, Player, bool)>(); 

            if (playerIndex < 0 || playerIndex >= numPlayers)
                throw new ArgumentException("Invalid player index");

            int rounds = numPlayers - 1;
            int half = numPlayers / 2;
            var rotation = new List<Player>(players);
            var result = new List<(int Round, Player Opponent, bool IsHome)>();

            for (int round = 0; round < rounds; ++round)
            {
                for (int i = 0; i < half; ++i)
                {
                    var home = rotation[i];
                    var away = rotation[numPlayers - 1 - i];

                    if (i == 0 && playerIndex == 0) 
                        result.Add((round + 1, away, true));
                    else if (home == players[playerIndex])
                        result.Add((round + 1, away, true));
                    else if (away == players[playerIndex])
                        result.Add((round + 1, home, false));
                }

                
                var last = rotation[numPlayers - 1];
                for (int i = numPlayers - 1; i > 1; --i)
                    rotation[i] = rotation[i - 1];
                rotation[1] = last;
            }

            return result;
        }
    }
}

