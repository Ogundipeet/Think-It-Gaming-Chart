using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Think_It_Gaming_Chart.Core.Entities;

namespace Think_It_Gaming_Chart.Core.Repositories.Queries
{
    public interface IGameQueryRepository
    {
        Task<IReadOnlyList<GameByPlaytime>> GetTopGamesByPlaytimeAsync(int? MinPlaytime, int? MaxPlaytime);
    }
}
