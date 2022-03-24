using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Think_It_Gaming_Chart.Core.Entities;
using Think_It_Gaming_Chart.Core.Repositories.Queries;

namespace Think_It_Gaming_Chart.UnitTest.Mock
{
    public class GameRepositoryMock
    {
        public static Mock<IGameQueryRepository> GameQueryRepository()
        {
            var games = new List<GameByPlaytime>()
            {
                new GameByPlaytime{ UserId = 88, Game = "The Witcher 3: Wild Hunt", PlayTime = 9, Genre= "RPG", Platforms = new List<string>(){"PC", "PS4", "Xbox One", "Nintendo Switch" } },
                new GameByPlaytime{ UserId = 1, Game = "The last of us 2", PlayTime = 100,Genre="FPS",Platforms = new List<string>(){"PS4", "PC" } },
                new GameByPlaytime{ UserId = 7, Game = "Hitman 3", PlayTime = 60, Genre= "Stealth", Platforms= new List<string>(){"PS4", "PS5", "Xbox One", "Nintendo Switch", "PC" } },
                new GameByPlaytime{ UserId = 99, Game = "Minecraft", PlayTime = 1002,Genre = "Sandbox",Platforms= new List<string>(){"PC" } },
                new GameByPlaytime{ UserId = 7, Game = "Hearthstone", PlayTime = 1000, Genre = "Card Game", Platforms = new List<string>(){"PC"}},
                new GameByPlaytime{ UserId = 7, Game = "FIFA", PlayTime = 2000, Genre = "Sport", Platforms = new List<string>(){ "PC", "PS4", "Xbox One" } }
            };

            var mockGameQueryRepository = new Mock<IGameQueryRepository>();

            mockGameQueryRepository.Setup(repo => repo.GetTopGamesByPlaytimeAsync(It.IsAny<int?>(), It.IsAny<int?>())).ReturnsAsync(
               (int? val, int? val2) =>
               {
                   var resp = games.FindAll(x => x.PlayTime >= val && x.PlayTime <= val2) as List<GameByPlaytime>;
                   var query = from game in resp.ToList()
                               group game by game.Game into gameGroup
                               select new GameByPlaytime
                               {
                                   Game = gameGroup.Key,
                                   PlayTime = gameGroup.Sum(c => c.PlayTime),
                                   UserId = gameGroup.Select(c => c.UserId).FirstOrDefault(),
                                   Genre = gameGroup.Select(c => c.Genre).FirstOrDefault(),
                                   Platforms = gameGroup.Select(c => c.Platforms).FirstOrDefault()
                               };

                   return query.Where(x => (val.HasValue && val2.HasValue ? x.PlayTime >= val && x.PlayTime <= val2
                   : (val.HasValue ? x.PlayTime >= val
                   : (val2.HasValue ? x.PlayTime <= val2 : x.PlayTime > 0))))
                       .OrderByDescending(y => y.PlayTime)
                       .ToList();
               }).Verifiable();

            return mockGameQueryRepository;
        }
    }
}
