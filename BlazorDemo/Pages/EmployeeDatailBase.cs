using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorDomain;

namespace BlazorDemo.Pages
{
    public class EmployeeDatailBase : ComponentBase
    {
        [Parameter]
        public string EmployId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    DepartmentId = 1,
                    No = "A01",
                    Name = "Nicky Carter",
                    BirthDate = new DateTime(1980, 1, 1)
                },
                new Employee
                {
                    Id = 2,
                    DepartmentId = 1,
                    No = "A02",
                    Name = "Mike",
                    BirthDate = new DateTime(1982, 1, 1)
                },
                new Employee
                {
                    Id = 3,
                    DepartmentId = 2,
                    No = "B01",
                    Name = "Bob",
                    BirthDate = new DateTime(1995, 1, 1)
                },
                new Employee
                {
                    Id = 4,
                    DepartmentId = 2,
                    No = "B02",
                    Name = "Mary",
                    BirthDate = new DateTime(1979, 1, 1)
                }
            };

            Employee = Employees.SingleOrDefault(x => x.Id == int.Parse(this.EmployId));

            return base.OnInitializedAsync();
        }
    }
}
