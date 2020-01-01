using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.DataModels
{
    public class ComplaintDetailForCreationData : ComplaintDetailForUpdationData
    {
        public string EmailAddress { get; set; }
    }
}
