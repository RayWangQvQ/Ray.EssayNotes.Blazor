using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("/api/Department/{departmentId}/[controller]")]
        public async Task<ActionResult<IList<Employee>>> GetAllForDepartment(int departmentId)
        {
            var re = await _employeeRepository.GetForDepartmentAsync(departmentId);
            return Ok(re);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetOne(int id)
        {
            var re = await _employeeRepository.GetOneAsync(id);
            return re;
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Employee update)
        {
            await this._employeeRepository.UpdateAsync(update);

            return Ok();
        }
    }
}
