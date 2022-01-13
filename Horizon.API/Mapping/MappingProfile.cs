using AutoMapper;
using Horizon.API.Model.Dto;
using Horizon.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource to Domain
            CreateMap<SaveFeedVisitDto, FeedVisit>();
            CreateMap<SaveAnimalDto, Animal>();
        }
    }
}
