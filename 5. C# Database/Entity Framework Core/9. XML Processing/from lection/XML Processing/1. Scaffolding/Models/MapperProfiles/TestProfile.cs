using _1._Scaffolding.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Scaffolding.Models.MapperProfiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Employee, PersonDto>()
                .ForMember(dto => dto.AddressText,
                    opt => opt.MapFrom(src => src.Address.AddressText))
                .ForMember(dto => dto.TownName,
                    opt => opt.MapFrom(src => src.Address.Town.Name));
        }
    }
}
