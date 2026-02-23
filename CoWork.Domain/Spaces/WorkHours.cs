using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Spaces
{
    public class WorkHours
    {
        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }
        private WorkHours() { }
        public WorkHours(TimeSpan start, TimeSpan end)
        {
            if (start >= end)throw new ArgumentException("Start time must be before end time.");

            Start = start;
            End = end;
        }
    }
}
