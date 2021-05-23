using System;

namespace ComplaintLoggingSystem.DataModels
{
    public class ComplaintDetailsData : ResponseMessageData
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ContactNumber { get; set; }

        public string City { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
