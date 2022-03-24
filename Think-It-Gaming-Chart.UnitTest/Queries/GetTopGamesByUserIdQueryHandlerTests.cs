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
    public class GetTopGamesByUserIdQueryHandlerTests
    {
        private readonly Mock<IUserQueryRepository> _mockUserQueryRepository;
        public GetTopGamesByUserIdQueryHandlerTests()
        {
            _mockUserQueryRepository = UserRepositoryMock.UserQueryRepository();
        }

        [Fact]
        public async Task GetTopGamesByUserIdAsyncPass()
        {
            var handler = new GetTopGamesByUserIdHandler(_mockUserQueryRepository.Object);
            var result = await handler.Handle(new GetTopGamesByUserIdQuery(7), CancellationToken.None);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTopGamesByUserIdAsyncFail()
        {
            var handler = new GetTopGamesByUserIdHandler(_mockUserQueryRepository.Object);
            var result = await handler.Handle(new GetTopGamesByUserIdQuery(2), CancellationToken.None);
            Assert.Empty(result);
        }
    }
}
