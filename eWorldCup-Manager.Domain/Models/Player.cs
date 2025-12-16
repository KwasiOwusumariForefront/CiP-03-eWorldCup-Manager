namespace eWorldCup_Manager.Domain.Models
{

	public class Player
    {
		public int Id { get; init; }
        public string Name { get; init; }

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString() => Name;

    }
}
