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
    public class GetTopGamesByUserIdHandler : IRequestHandler<GetTopGamesByUserIdQuery, List<UserResponse>>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        public GetTopGamesByUserIdHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<List<UserResponse>> Handle(GetTopGamesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await Task.FromResult(await _userQueryRepository.GetTopGamesByUserIdAsync(request.UserId).ConfigureAwait(false));
            var response = UserMapper.Mapper.Map<List<UserResponse>>(user);
            return response;

        }
    }
}
