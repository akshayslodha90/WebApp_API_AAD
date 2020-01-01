using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Entities
{
    public class ComplaintDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string IssueDescription { get; set; }

        [MaxLength(50)]
        public string Area { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
