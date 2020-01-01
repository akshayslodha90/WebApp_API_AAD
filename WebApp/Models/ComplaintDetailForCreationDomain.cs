using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Models
{
    public class ComplaintDetailForCreationDomain : ComplaintDetailForUpdationDomain
    {
        public string EmailAddress { get; set; }
    }
}
