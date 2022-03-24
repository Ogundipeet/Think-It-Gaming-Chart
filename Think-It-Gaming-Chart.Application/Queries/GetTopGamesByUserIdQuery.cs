using System;
using System.Collections.Generic;
using MediatR;
using Think_It_Gaming_Chart.Application.Responses;
using Think_It_Gaming_Chart.Core.Entities;

namespace Think_It_Gaming_Chart.Application.Queries
{
    public record GetTopGamesByUserIdQuery(int UserId) : IRequest<List<UserResponse>>;
}
