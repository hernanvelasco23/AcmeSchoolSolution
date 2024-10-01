using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Domain
{
    public class CoursePeriod
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public CoursePeriod(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException("Start date must be before the end date.");
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool OverlapsWith(CoursePeriod otherPeriod)
        {
            return !(EndDate < otherPeriod.StartDate || StartDate > otherPeriod.EndDate);
        }
    }

}
