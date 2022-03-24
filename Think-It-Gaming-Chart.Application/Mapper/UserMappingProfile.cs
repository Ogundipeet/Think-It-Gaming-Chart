using System;
using AutoMapper;
using Think_It_Gaming_Chart.Application.Responses;
using Think_It_Gaming_Chart.Core.Entities;

namespace Think_It_Gaming_Chart.Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<GameByPlaytime, UserResponse>().ReverseMap();
        }
    }
}
