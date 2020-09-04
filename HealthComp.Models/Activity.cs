using System;
using System.Collections.Generic;
using System.Text;

namespace HealthComp.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int TimeToCompleteInMinutes { get; set; }
    }
}
