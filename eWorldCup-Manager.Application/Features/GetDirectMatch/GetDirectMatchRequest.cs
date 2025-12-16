using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Repositories;
using eWorldCup_Manager.Models;
using MediatR;
using System.Threading.Tasks;

namespace eWorldCup_Manager.Application.Features.GetDirectMatch
{
    public class GetDirectMatchRequest : IRequest<DirectMatch>
    {
        public int Players { get; set; }
        public int PlayerIndex { get; set; }
        public int Round { get; set; }
    }

    public class GetDirectMatchHandler : IRequestHandler<GetDirectMatchRequest, DirectMatch>
    {
        public async Task<DirectMatch> Handle(GetDirectMatchRequest request, CancellationToken cancellationToken)
        {
            int opponentIndex = DirectMatchService.GetDirectMatch(request.Players, request.PlayerIndex, request.Round);
            var players = PlayerList.List.ToList();

            return await Task.FromResult(new DirectMatch
            {
                PlayerIndex = request.PlayerIndex,
            });
        }
    }
}
