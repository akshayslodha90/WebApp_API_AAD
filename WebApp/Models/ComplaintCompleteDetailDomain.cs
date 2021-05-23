using System;

namespace ComplaintLoggingSystem.Models
{
    public class ComplaintCompleteDetailDomain : ComplaintDetailsDomain
    {
        public string EmailAddress { get; set; }

        public string IssueDescription { get; set; }

        public string Area { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
