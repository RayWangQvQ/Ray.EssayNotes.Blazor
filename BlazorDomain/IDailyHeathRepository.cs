using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDomain
{
    public interface IDailyHeathRepository
    {
        Task UpdateForDepartmentAsync(int departmentId, DateTime date, IList<DailyHealth> dailyHealths);

        Task<IList<DailyHealth>> GetByDepartmentAxync(int departmentId, DateTime date);
    }
}
