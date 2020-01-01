using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.DataModels
{
    public class ComplaintCompleteDetailData : ComplaintDetailsData
    {
        public string EmailAddress { get; set; }

        public string IssueDescription { get; set; }

        public string Area { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
