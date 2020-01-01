using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
    public class ComplaintDetailsProfile : Profile
    {
        public ComplaintDetailsProfile()
        {
            CreateMap<Entities.ComplaintDetail, Models.ComplaintDetailDto>();
            CreateMap<Entities.ComplaintDetail, Models.ComplaintCompleteDetailDto>();

            CreateMap<Models.ComplaintDetailForCreationDto, Entities.ComplaintDetail>()
                .ForMember(
                dest => dest.LastModifiedDate,
                opt=>opt.MapFrom(src=> DateTime.UtcNow)
                )
                 .ForMember(
                dest => dest.CreatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)
                );
                
            CreateMap<Models.ComplaintDetailForUpdateDto, Entities.ComplaintDetail>()
                 .ForMember(
                dest => dest.LastModifiedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)
                );
        }
    }
}
