using Core.Interfaces;

namespace Core.Domain
{

    public class PlayerList : List<Player>
    {
        public static readonly IReadOnlyList<Player> List = new List<Player>
        {
            new Player(1, "Alice"),   new Player(2, "Bob"),     new Player(3, "Charlie"), new Player(4, "Diana"),
            new Player(5, "Ethan"),   new Player(6, "Fiona"),   new Player(7, "George"),  new Player(8, "Hannah"),
            new Player(9, "Isaac"),   new Player(10, "Julia"),  new Player(11, "Kevin"),  new Player(12, "Laura"),
            new Player(13, "Michael"),new Player(14, "Nina"),   new Player(15, "Oscar"),  new Player(16, "Paula"),
            new Player(17, "Quentin"),new Player(18, "Rachel"), new Player(19, "Samuel"), new Player(20, "Tina")
        }.AsReadOnly();

    }
}
