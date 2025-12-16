using eWorldCup_Manager.Domain.Repositories;
namespace eWorldCup_Manager.Applications.Services
{
    public class DirectMatchService
    {
        public static int GetDirectMatch(int player, int playerindex, int roundnumber)
        {
            if (playerindex == roundnumber)
                return player - 1;        // player i faces the fixed player
            if (playerindex == player - 1)
                return roundnumber;            // fixed player faces player d
            return (player - 2 + 2 * roundnumber - playerindex) % (player - 1);
        }

        public static void DirectMatchHandler(int playerss, int playerindex, int roundss)
        {
            int directMatch = GetDirectMatch(playerss, playerindex, roundss);
            Console.WriteLine(directMatch);
            Console.WriteLine($"{PlayerList.List[directMatch].Name} vs {PlayerList.List[playerindex].Name}");
        }

    }
}
