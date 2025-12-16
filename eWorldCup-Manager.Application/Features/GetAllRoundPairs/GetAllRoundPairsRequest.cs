using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Models;
using eWorldCup_Manager.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorldCup_Manager.Application.Features.GetAllRoundPairs
{
    public class GetAllRoundPairsRequest : IRequest<Match>
    {
        public int RoundNum { get; set; }
    }

    public class GetAllRoundPairsHandler : IRequestHandler<GetAllRoundPairsRequest, Match>
    {
        public async Task<Match> Handle(GetAllRoundPairsRequest request, CancellationToken cancellationToken)
        {
            var players = PlayerList.List;
            var pairs = RoundRobinService.GetRoundPairs(players.ToList(), request.RoundNum);

            return await Task.FromResult(new Match
            {
                Round = request.RoundNum,
                Pairs = pairs.Select(p => new Pair
                {
                    Home = (p.Home.Name),
                    Away = (p.Away.Name)
                }).ToList()
            });
        }
    }
}
