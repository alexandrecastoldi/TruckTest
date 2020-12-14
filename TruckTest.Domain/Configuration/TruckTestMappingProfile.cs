using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TruckTest.Domain.Dtos;
using TruckTest.Domain.Entities;
using TruckTest.Domain.Entities.Enum;

namespace TruckTest.Domain.Configuration
{
    public class TruckTestMappingProfile : Profile
    {
        public TruckTestMappingProfile()
        {
            CreateMap<Truck, TruckDto>()
                .ForMember(d => d.ModelName, d => d.MapFrom(src => src.Model.ToString()));

            CreateMap<TruckDto, Truck>();
        }
    }
}
