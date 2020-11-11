using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Domain.Models.Journals;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Aplication.AutoMapper.Journals
{
    public class JournalsMappingProfile : Profile
    {
        public JournalsMappingProfile()
        {
            CreateMap<Journal, JournalDTO>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));
        }
    }
}
