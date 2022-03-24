using System;
using Microsoft.Extensions.Configuration;
using Think_It_Gaming_Chart.Core.Repositories.Queries.Base;

namespace Think_It_Gaming_Chart.Infrastructure.Repositories.Queries.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly IConfiguration _configuration;
        public QueryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
