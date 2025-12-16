using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Models;
using MediatR;
using System.Threading.Tasks;

namespace eWorldCup_Manager.Application.Features.GetPairsLeftAfterRounds
{
    public class GetPairsLeftAfterRoundsRequest : IRequest<PairsLeftAfterRounds>
    {
        public long Players { get; set; }
        public long Rounds { get; set; }
    }

    public class GetPairsLeftAfterRoundsHandler : IRequestHandler<GetPairsLeftAfterRoundsRequest, PairsLeftAfterRounds>
    {
        public async Task<PairsLeftAfterRounds> Handle(GetPairsLeftAfterRoundsRequest request, CancellationToken cancellationToken)
        {
            var pairsLeft = PairsLeftAfterRoundsService.CalculatePairsLeftAfterRounds(request.Players, request.Rounds);
            
            return await Task.FromResult(new PairsLeftAfterRounds
            {
                PairsLeft = pairsLeft
            });
        }
    }
}
