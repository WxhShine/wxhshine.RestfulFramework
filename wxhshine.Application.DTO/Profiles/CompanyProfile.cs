using AutoMapper;
using System;
using System.Linq;
using wxhshine.Domian.Entities;

namespace wxhshine.Application.DTO.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(dto => dto.CompanyName, entity => entity.MapFrom(x => x.Name));
        }
    }
}
