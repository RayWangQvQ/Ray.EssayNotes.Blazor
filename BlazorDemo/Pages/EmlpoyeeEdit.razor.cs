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
    public partial class EmlpoyeeEdit
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected string AddOrEdit => string.IsNullOrWhiteSpace(EmployeeId) ? "Add" : "Edit";

        protected override async Task OnInitializedAsync()
        {
            this.Employee = await this.HttpClient.GetFromJsonAsync<Employee>($"api/employee/{EmployeeId}");

            await base.OnInitializedAsync();

            return;
        }
    }
}
