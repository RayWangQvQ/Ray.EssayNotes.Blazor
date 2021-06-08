using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

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

        private bool IsValid { get; set; }
        public string Message { get; set; }
        public string CssClass { get; set; }

        private bool Valid()
        {
            if (string.IsNullOrWhiteSpace(this.Employee.No)) return false;

            return true;
        }

        protected override async Task OnInitializedAsync()
        {
            this.Employee = await this.HttpClient.GetFromJsonAsync<Employee>($"api/employee/{EmployeeId}");
            await base.OnInitializedAsync();
        }

        public async Task OnValidSubmit()
        {
            IsValid = Valid();

            if (IsValid)
            {
                var content = JsonContent.Create<Employee>(this.Employee);
                await this.HttpClient.PutAsync($"api/employee", content);
                this.Message = "成功";
                return;
            }
            this.Message = "失败";
        }

        private void HandleInvalidSubmit()
        {
            CssClass = "alert alert-danger";
            Message = "表单验证失败";
        }
    }
}
