using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DailyHealthController : ControllerBase
    {
        private readonly IDailyHeathRepository _dailyHeathRepository;

        public DailyHealthController(IDailyHeathRepository dailyHeathRepository)
        {
            this._dailyHeathRepository = dailyHeathRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<DailyHealth>>> Get(int departmentId, DateTime date)
        {
            var re = await _dailyHeathRepository.GetByDepartmentAxync(departmentId, date);
            return Ok(re);
        }

        [HttpPost]
        public async Task<ActionResult<IList<DailyHealth>>> Get(int departmentid, DateTime date, List<DailyHealth> dailyHealths)
        {
            await _dailyHeathRepository.UpdateForDepartmentAsync(departmentid, date, dailyHealths);
            return dailyHealths;
        }
    }
}
