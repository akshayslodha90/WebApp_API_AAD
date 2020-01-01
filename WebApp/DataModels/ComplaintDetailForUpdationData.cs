﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.DataModels
{
    public class ComplaintDetailForUpdationData : ResponseMessageData
    {
        public string ContactNumber { get; set; }

        public string Title { get; set; }

        public string IssueDescription { get; set; }

        public string Area { get; set; }

        public string City { get; set; }
    }
}
