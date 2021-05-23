using System;

namespace ComplaintLoggingSystem.Models
{
    public class ComplaintDetailsDomain
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ContactNumber { get; set; }

        public string City { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
