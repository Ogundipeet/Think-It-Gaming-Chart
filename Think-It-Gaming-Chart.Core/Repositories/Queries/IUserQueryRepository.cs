using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Think_It_Gaming_Chart.Core.Entities;

namespace Think_It_Gaming_Chart.Core.Repositories.Queries
{
    public interface IUserQueryRepository
    {
        Task<IReadOnlyList<GameByPlaytime>> GetTopGamesByUserIdAsync(int UserId);
    }
}
