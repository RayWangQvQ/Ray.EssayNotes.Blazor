using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

        protected override async Task OnInitializedAsync()
        {
            Employees = await this.HttpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/department");

            await base.OnInitializedAsync();

            return;
        }
    }
}
