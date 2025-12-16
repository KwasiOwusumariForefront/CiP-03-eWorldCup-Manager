using Core.Domain;
using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Interfaces;
using eWorldCup_Manager.Models;
using Microsoft.AspNetCore.Mvc;


namespace eWorldCup_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eWorldCup_ManagerController : ControllerBase
    {

        //GET	/rounds/max? n = Returnerar max antal rundor för n deltagare(n−1).
        [HttpGet("rounds/{max}")]
        public ActionResult<MaxRounds> getDirectMatch(long max)
        {
            var result = MaxRoundsService.CalculateMaxRounds(max);
            var maxRounds = new MaxRounds { rounds = result };
            return Ok(maxRounds);
        }

        //GET	/rounds/:d Returnerar alla matcher i runda d(1 ≤ d ≤ n−1).  
        [HttpGet("{roundNum}")]
        public IActionResult GetRound(int roundNum)
        {
            var players = PlayerList.List; // Your readonly list of players
            var pairs = RoundRobinService.GetRoundPairs(players.ToList(), roundNum);

            var response = new
            {
                round = roundNum,
                pairs = pairs.Select(p => new
                {
                    home = p.Home.Name,
                    away = p.Away.Name
                }).ToList()
            };

            return Ok(response);
        }


        //GET	/match/remaining? n = &D = Returnerar antal återstående unika par efter att D rundor har spelats.
        [HttpGet("match/remaining")]
        public ActionResult<PairsLeftAfterRounds> getPairsLeft([FromQuery] long i, [FromQuery] long d)
        {
            var result = PairsLeftAfterRoundsService.CalculatePairsLeftAfterRounds(i, d);
            return Ok(result);
        }

        //GET   /match? n = &i = &d = Returnerar direkt vem spelare i möter i runda d (0-baserat index).
        [HttpGet("match")]
        public IActionResult getDirectMatch([FromQuery] int n, [FromQuery] int i, [FromQuery] int d)
        {
            var result = DirectMatchService.GetDirectMatch(n, i, d);
            return Ok(new { opponentIndex = result });

        }
        //GET	/player/:i/schedule Returnerar hela schemat för spelare i över rundor 1..n−1.
        [HttpGet("{playerIndex}/schedule")]
        public IActionResult GetPlayerSchedule(int playerIndex)
        {
            var players = PlayerList.List.ToList();

            var player = players[playerIndex];
            var schedule = RoundRobinService2.GetPlayerRounds(players, playerIndex);

            // Convert to JSON-friendly format
            var response = new
            {
                player = player.Name,
                rounds = schedule.Select(r => new
                {
                    round = r.Round,
                    opponent = r.Opponent.Name,
                    home = r.IsHome
                }).ToList()
            };

            return Ok(response);
        }
        //GET	/player/:i/round/:d Alias till “direktfråga” för spelare i i runda d, men med namn/objekt.
        [HttpGet("{playerIndex}/round/{roundNum}")]
        public IActionResult GetDirectMatch([FromQuery] int player, [FromQuery] int playerindex, [FromQuery] int round )
        {
            int directMatchIndex = DirectMatchService.GetDirectMatch(player, playerindex, round);
            var players = PlayerList.List.ToList();
            var response = new
            {
                player = players[playerindex].Name,
                opponent = players[directMatchIndex].Name,
                round = round
            };
            return Ok(response);
        }
    }
}
