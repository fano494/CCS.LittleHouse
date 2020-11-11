using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Domain.Models.Journals;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Aplication.AutoMapper.Journals
{
    public class EntriesMappingProfile : Profile
    {
        public EntriesMappingProfile()
        {
            CreateMap<Entry, EntryDTO>().ForMember(dest => dest.JournalId, opt => opt.MapFrom(src => src.Journal.Id));
        }
    }
}
