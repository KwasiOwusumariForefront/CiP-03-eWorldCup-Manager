using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Models;
using eWorldCup_Manager.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorldCup_Manager.Application.Features.GetPlayerRounds
{
    public class GetPlayerRoundsRequest : IRequest<Schedule>
    {
        public int PlayerIndex { get; set; }
    }

    public class GetPlayerRoundsHandler : IRequestHandler<GetPlayerRoundsRequest, Schedule>
    {
        public async Task<Schedule> Handle(GetPlayerRoundsRequest request, CancellationToken cancellationToken)
        {
            var players = PlayerList.List.ToList();

            var player = players[request.PlayerIndex];
            var schedule = RoundRobinService2.GetPlayerRounds(players, request.PlayerIndex);

            return await Task.FromResult(new Schedule
            {
                Player = player.Name,
                Rounds = schedule.Select(r => new ScheduleRound
                {
                    Round = r.Round,
                    Opponent = r.Opponent.Name,
                }).ToList()
            });
        }
    }
}
