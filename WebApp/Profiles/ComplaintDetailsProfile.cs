using AutoMapper;
using ComplaintLoggingSystem.DataModels;
using ComplaintLoggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using ComplaintLoggingSystem.Helpers;

namespace CourseLibrary.API.Profiles
{
    public class ComplaintDetailsProfile : Profile
    {
        public ComplaintDetailsProfile()
        {
            CreateMap<ComplaintDetailsData, ComplaintDetailsDomain>();
            CreateMap<ComplaintCompleteDetailData, ComplaintCompleteDetailDomain>();
            CreateMap<ComplaintDetailForCreationDomain, ComplaintDetailForCreationData>()
                .ForMember
                (dest=>dest.EmailAddress,
                opt=>opt.MapFrom(src=>UserToolBox.GetEmailId()));
            CreateMap<ComplaintDetailForUpdationDomain, ComplaintDetailForUpdationData>();
            CreateMap<ComplaintCompleteDetailData, ComplaintDetailForUpdationDomain>();
        }
    }
}
