using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
