using ComplaintLoggingSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Services
{
    public class MockComplaintDetailsSystem : IComplaintDetailsSystem
    {
        public Task<string> CreateComplaintDetail(ComplaintDetailForCreationData complaintDetailForCreationData)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteComplaintDetail(Guid complaintId)
        {
            throw new NotImplementedException();
        }

        public async Task<ComplaintCompleteDetailData> GetComplaintDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ComplaintDetailsData>> GetComplaintDetails(string emailId)
        {
            var complaintDetails = new List<ComplaintDetailsData>
            {
                new ComplaintDetailsData()
                {
                    City="Pune",
                    ContactNumber="",
                    Id=Guid.NewGuid(),
                    LastModifiedDate=DateTime.UtcNow,
                    Title=""

                },
                new ComplaintDetailsData()
                {
                    City="Pune",
                    ContactNumber="",
                    Id=Guid.NewGuid(),
                    LastModifiedDate=DateTime.UtcNow,
                    Title=""
                }
            };

            return complaintDetails;
        }

        public Task<string> UpdateComplaintDetail(Guid complaintId, ComplaintDetailForUpdationData complaintDetailForCreationData)
        {
            throw new NotImplementedException();
        }
    }
}
