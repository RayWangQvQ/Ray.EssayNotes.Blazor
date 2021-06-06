using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmnetRepository _departmnetRepository;

        public DepartmentController(IDepartmnetRepository departmnetRepository)
        {
            this._departmnetRepository = departmnetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var departments = await _departmnetRepository.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetOne(int id)
        {
            var re = await _departmnetRepository.GetByIdAsync(id);
            return Ok(re);
        }
    }
}
