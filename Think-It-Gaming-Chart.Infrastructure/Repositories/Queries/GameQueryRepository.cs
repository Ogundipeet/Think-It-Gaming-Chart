using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Think_It_Gaming_Chart.Core.Entities;
using Think_It_Gaming_Chart.Core.Entities.Base;
using Think_It_Gaming_Chart.Core.Repositories.Queries;
using Think_It_Gaming_Chart.Infrastructure.Repositories.Queries.Base;

namespace Think_It_Gaming_Chart.Infrastructure.Repositories.Queries
{
    public class GameQueryRepository : QueryRepository<GameByPlaytime>, IGameQueryRepository
    {
        private readonly string _connectionString;
        public GameQueryRepository(IConfiguration configuration)
            : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("FilePath");
        }


        public async Task<IReadOnlyList<GameByPlaytime>> GetTopGamesByPlaytimeAsync(int? MinPlaytime , int? MaxPlaytime)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_connectionString))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {

                        var games = JsonConvert.DeserializeObject<GameByPlayTimeList>(apiResponse);

                        var query = from game in games.data.ToList()
                                    group game by game.Game into gameGroup
                                    select new GameByPlaytime
                                    {
                                        Game = gameGroup.Key,
                                        PlayTime = gameGroup.Sum(c => c.PlayTime),
                                        UserId = gameGroup.Select(c => c.UserId).FirstOrDefault(),
                                        Genre = gameGroup.Select(c => c.Genre).FirstOrDefault(),
                                        Platforms = gameGroup.Select(c => c.Platforms).FirstOrDefault()
                                    };

                        return query.Where(x => (MinPlaytime.HasValue && MaxPlaytime.HasValue ? x.PlayTime >= MinPlaytime && x.PlayTime <= MaxPlaytime
                        : (MinPlaytime.HasValue ? x.PlayTime >= MinPlaytime
                        : (MaxPlaytime.HasValue ? x.PlayTime <= MaxPlaytime : x.PlayTime > 0))))
                            .OrderByDescending(y => y.PlayTime)
                            .ToList();
                    }
                    catch (System.Exception ex)
                    {
                        return new List<GameByPlaytime>();
                    }
                }
            }
        }
    }
}
