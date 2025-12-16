using eWorldCup_Manager.Domain.Models;

namespace eWorldCup_Manager.Domain.Models
{
    public class Match
    {
        public int Round { get; set; }
        public IEnumerable<Pair> Pairs { get; set; } = [];
    }
}