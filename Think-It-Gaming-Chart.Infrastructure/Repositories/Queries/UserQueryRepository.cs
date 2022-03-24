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
    public class UserQueryRepository : QueryRepository<GameByPlaytime>, IUserQueryRepository
    {
        private readonly string _connectionString;
        public UserQueryRepository(IConfiguration configuration)
            : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("FilePath");
        }

        public async Task<IReadOnlyList<GameByPlaytime>> GetTopGamesByUserIdAsync(int UserId)
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
                                    where game.UserId == UserId
                                    group game by game.Game into gameGroup
                                    select new GameByPlaytime
                                    {
                                        Game = gameGroup.Key,
                                        PlayTime = gameGroup.Sum(c => c.PlayTime),
                                        UserId = gameGroup.Select(c => c.UserId).FirstOrDefault(),
                                        Genre = gameGroup.Select(c => c.Genre).FirstOrDefault(),
                                        Platforms = gameGroup.Select(c => c.Platforms).FirstOrDefault()
                                    };

                        return query.OrderByDescending(y => y.PlayTime).ToList();
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
