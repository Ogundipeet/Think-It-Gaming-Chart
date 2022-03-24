using System;
using AutoMapper;
using Think_It_Gaming_Chart.Application.Responses;
using Think_It_Gaming_Chart.Core.Entities;

namespace Think_It_Gaming_Chart.Application.Mapper
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<GameByPlaytime, GameResponse>().ReverseMap();
        }
    }
}
