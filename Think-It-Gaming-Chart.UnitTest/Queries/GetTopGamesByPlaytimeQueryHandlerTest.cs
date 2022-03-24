using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Think_It_Gaming_Chart.Application.Handlers.QueryHandlers;
using Think_It_Gaming_Chart.Application.Queries;
using Think_It_Gaming_Chart.Core.Repositories.Queries;
using Think_It_Gaming_Chart.UnitTest.Mock;
using Xunit;

namespace Think_It_Gaming_Chart.UnitTest.Queries
{
    public class GetTopGamesByPlaytimeQueryHandlerTest
    {
        private readonly Mock<IGameQueryRepository> _mockGameQueryRepository;
        public GetTopGamesByPlaytimeQueryHandlerTest()
        {
            _mockGameQueryRepository = GameRepositoryMock.GameQueryRepository();
        }
        [Fact]
        public async Task GetTopGamesByPlaytimeAsyncPass()
        {
            var handler = new GetTopGamesByPlaytimeHandler(_mockGameQueryRepository.Object);
            var result = await handler.Handle(new GetTopGamesByPlaytimeQuery(200,2000), CancellationToken.None);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTopGamesByPlaytimeAsyncFail()
        {
            var handler = new GetTopGamesByPlaytimeHandler(_mockGameQueryRepository.Object);
            var result = await handler.Handle(new GetTopGamesByPlaytimeQuery(0, 0), CancellationToken.None);
            Assert.Empty(result);
        }

    }
}
