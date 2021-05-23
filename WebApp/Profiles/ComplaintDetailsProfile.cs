using AutoMapper;
using ComplaintLoggingSystem.DataModels;
using ComplaintLoggingSystem.Helpers;
using ComplaintLoggingSystem.Models;

namespace ComplaintLoggingSystem.Profiles
{
    public class ComplaintDetailsProfile : Profile
    {
        public ComplaintDetailsProfile()
        {
            CreateMap<ComplaintDetailsData, ComplaintDetailsDomain>();
            CreateMap<ComplaintCompleteDetailData, ComplaintCompleteDetailDomain>();
            CreateMap<ComplaintDetailForCreationDomain, ComplaintDetailForCreationData>()
                .ForMember
                (dest => dest.EmailAddress,
                opt => opt.MapFrom(src => UserToolBox.GetEmailId()));
            CreateMap<ComplaintDetailForUpdationDomain, ComplaintDetailForUpdationData>();
            CreateMap<ComplaintCompleteDetailData, ComplaintDetailForUpdationDomain>();
        }
    }
}
