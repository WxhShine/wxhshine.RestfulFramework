using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(dto => dto.CompanyName, entity => entity.MapFrom(x => x.Name));
        }
    }
}
