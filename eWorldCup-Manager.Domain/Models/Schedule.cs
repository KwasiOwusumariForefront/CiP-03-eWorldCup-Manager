namespace eWorldCup_Manager.Domain.Models
{
    public class Schedule
    {
        public string Player { get; set; }
        public IEnumerable<ScheduleRound> Rounds { get; set; } = [];
    }
}
