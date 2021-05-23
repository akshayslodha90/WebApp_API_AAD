using System;

namespace CourseLibrary.API.Models
{
    public class ComplaintCompleteDetailDto : ComplaintDetailDto
    {
        public string EmailAddress { get; set; }

        public string IssueDescription { get; set; }

        public string Area { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
