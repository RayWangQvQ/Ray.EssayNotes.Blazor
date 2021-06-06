using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorDomain;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorDemo.Pages
{
    public partial class EmployeeDatail
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public string EmployId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected async override Task OnInitializedAsync()
        {
            Employee = await this.HttpClient.GetFromJsonAsync<Employee>($"api/employee/{this.EmployId}");

            await base.OnInitializedAsync();

            return;
        }
    }
}
