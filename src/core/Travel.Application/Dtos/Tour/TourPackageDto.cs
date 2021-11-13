using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Travel.Application.Common.Mappings;
using Travel.Domain.Entities;
using Travel.Domain.Enums;

namespace Travel.Application.Dtos.Tour
{
    public class TourPackageDto : IMapFrom<TourPackage>
    {

        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TourPackage, TourPackageDto>().ForMember(d => d.Currency, opt => opt.MapFrom(s => (int)s.Currency));
        }
    }
}
