using eWorldCup_Manager.Domain.Repositories;
using eWorldCup_Manager.Application.Features.GetAllRoundPairs;
using eWorldCup_Manager.Application.Features.GetPlayerRounds;
using eWorldCup_Manager.Application.Features.GetMaxRounds;
using eWorldCup_Manager.Application.Features.GetPairsLeftAfterRounds;
using eWorldCup_Manager.Application.Features.GetDirectMatch;
using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Interfaces;
using eWorldCup_Manager.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;


namespace eWorldCup_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eWorldCup_ManagerController : ControllerBase 
    {
        private readonly ISender _sender;
        public eWorldCup_ManagerController (ISender sender) {
            _sender = sender;
        }

        //GET	/rounds/max? n = Returnerar max antal rundor för n deltagare(n−1).
        [HttpGet("rounds/{max}")]
        public async Task<IActionResult> GetMaxRounds(long max)
        {
            var request = new GetMaxRoundsRequest
            {
                Players = max
            };
            var result = await _sender.Send(request);
            return Ok(result);
        }

        //GET	/rounds/:d Returnerar alla matcher i runda d(1 ≤ d ≤ n−1).  
        [HttpGet("{roundNum}")]
        public async Task<IActionResult> GetRound(int roundNum)
        {
            var request = new GetAllRoundPairsRequest
            {
                RoundNum = roundNum
            };
            var result = await _sender.Send(request);
            return Ok(result);
        }


        //GET	/match/remaining? n = &D = Returnerar antal återstående unika par efter att D rundor har spelats.
        [HttpGet("match/remaining")]
        public async Task<IActionResult> GetPairsLeft([FromQuery] long i, [FromQuery] long d)
        {
            var request = new GetPairsLeftAfterRoundsRequest
            {
                Players = i,
                Rounds = d
            };
            var result = await _sender.Send(request);
            return Ok(result);
        }

        //GET   /match? n = &i = &d = Returnerar direkt vem spelare i möter i runda d (0-baserat index).
        [HttpGet("match")]
        public async Task<IActionResult> GetDirectMatch([FromQuery] int n, [FromQuery] int i, [FromQuery] int d)
        {
            var request = new GetDirectMatchRequest
            {
                Players = n,
                PlayerIndex = i,
                Round = d
            };
            var result = await _sender.Send(request);
            return Ok(result);
        }
        //GET	/player/:i/schedule Returnerar hela schemat för spelare i över rundor 1..n−1.
        [HttpGet("{playerIndex}/schedule")]
        public async Task<IActionResult> GetPlayerSchedule(int playerIndex)
        {
            var request = new GetPlayerRoundsRequest
            {
                PlayerIndex = playerIndex
            };
            var result = await _sender.Send(request);
            return Ok(result);
        }
        //GET	/player/:i/round/:d Alias till “direktfråga” för spelare i i runda d, men med namn/objekt.
        [HttpGet("{playerIndex}/round/{roundNum}")]
        public IActionResult GetPlayerRoundMatch([FromQuery] int player, [FromQuery] int playerindex, [FromQuery] int round )
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
