using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Think_It_Gaming_Chart.Application.Mapper;
using Think_It_Gaming_Chart.Application.Queries;
using Think_It_Gaming_Chart.Application.Responses;
using Think_It_Gaming_Chart.Core.Entities;
using Think_It_Gaming_Chart.Core.Repositories.Queries;

namespace Think_It_Gaming_Chart.Application.Handlers.QueryHandlers
{
    public class GetTopGamesByPlaytimeHandler : IRequestHandler<GetTopGamesByPlaytimeQuery, List<GameResponse>>
    {
        private readonly IGameQueryRepository _gameQueryRepository;
        public GetTopGamesByPlaytimeHandler(IGameQueryRepository gameQueryRepository)
        {
            _gameQueryRepository = gameQueryRepository;
        }

        public async Task<List<GameResponse>> Handle(GetTopGamesByPlaytimeQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameQueryRepository.GetTopGamesByPlaytimeAsync(request.MinPlaytime, request.MaxPlaytime);
            var response = GameMapper.Mapper.Map<List<GameResponse>>(games);
            return response;
        }
    }
}
