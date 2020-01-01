using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class ComplaintDetailForCreationDto : ComplaintDetailForUpdateDto
    {
        public string EmailAddress { get; set; }
    }
}
