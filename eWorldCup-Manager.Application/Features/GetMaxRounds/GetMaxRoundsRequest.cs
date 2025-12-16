using eWorldCup_Manager.Applications.Services;
using eWorldCup_Manager.Domain.Models;
using eWorldCup_Manager.Models;
using MediatR;
using System.Threading.Tasks;

namespace eWorldCup_Manager.Application.Features.GetMaxRounds
{
    public class GetMaxRoundsRequest : IRequest<MaxRounds>
    {
        public long Players { get; set; }
    }

    public class GetMaxRoundsHandler : IRequestHandler<GetMaxRoundsRequest, MaxRounds>
    {
        public async Task<MaxRounds> Handle(GetMaxRoundsRequest request, CancellationToken cancellationToken)
        {
            var result = MaxRoundsService.CalculateMaxRounds(request.Players);
            
            return await Task.FromResult(new MaxRounds
            {
                rounds = result
            });
        }
    }
}
