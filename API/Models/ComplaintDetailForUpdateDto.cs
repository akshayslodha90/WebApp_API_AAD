using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class ComplaintDetailForUpdateDto
    {
        
        public string ContactNumber { get; set; }

        public string Title { get; set; }

        public string IssueDescription { get; set; }

        public string Area { get; set; }

        public string City { get; set; }
    }
}
