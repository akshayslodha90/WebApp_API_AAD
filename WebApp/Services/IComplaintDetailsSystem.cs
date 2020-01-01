using ComplaintLoggingSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Services
{
    public interface IComplaintDetailsSystem
    {
        Task<List<ComplaintDetailsData>> GetComplaintDetails(string emailId);

        Task<ComplaintCompleteDetailData> GetComplaintDetail(Guid id);

        Task<string> CreateComplaintDetail(ComplaintDetailForCreationData complaintDetailForCreationData);

        Task<string> UpdateComplaintDetail(Guid complaintId, ComplaintDetailForUpdationData complaintDetailForCreationData);

        Task<string> DeleteComplaintDetail(Guid complaintId);
    }
}
