using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDomain
{
    public class Employee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string No { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
