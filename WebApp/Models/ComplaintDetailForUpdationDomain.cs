using System.ComponentModel.DataAnnotations;

namespace ComplaintLoggingSystem.Models
{
    public class ComplaintDetailForUpdationDomain
    {
        [MaxLength(10)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "* required field")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "* required field")]
        [MaxLength(500)]
        public string IssueDescription { get; set; }

        [MaxLength(50)]
        public string Area { get; set; }

        [Required(ErrorMessage = "* required field")]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
