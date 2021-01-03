using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Data.Entities
{
    public class Reports
    {
        public Guid UUID { get; set; }
        public DateTime ReportRequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
    public enum ReportStatus
    {
        GettingReady = 0,
        Completed
    }
}
