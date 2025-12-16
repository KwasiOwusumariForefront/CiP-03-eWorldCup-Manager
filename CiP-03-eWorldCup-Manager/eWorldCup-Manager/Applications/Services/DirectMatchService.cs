using Core.Interfaces;
using Core.Domain;
namespace eWorldCup_Manager.Applications.Services
{
    public class DirectMatchService
    {
        public static int GetDirectMatch(int player, int playerindex, int roundnumber)
        {
            if (playerindex == roundnumber)
                return player - 1;        
            if (playerindex == player - 1)
                return roundnumber;            
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
