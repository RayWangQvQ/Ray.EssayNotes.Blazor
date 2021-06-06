using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDomain
{
    public class DailyHealth
    {
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public HealthCondition HealthCondition { get; set; }

        public float Temperature { get; set; }

        public string Remark { get; set; }
    }

    public enum HealthCondition
    {
        Healthy,
        Cold,
        Fever,
        Other
    }
}
