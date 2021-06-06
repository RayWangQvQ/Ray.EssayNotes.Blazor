using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.EntityFrameworkCore;

namespace BlazorRepository
{
    public class DailyHeathRepository : IDailyHeathRepository
    {
        private readonly MyDbContext _myDbContext;

        public DailyHeathRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task<IList<DailyHealth>> GetByDepartmentAxync(int departmentId, DateTime date)
        {
            var employeeIds = await _myDbContext.Employees
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => x.Id)
                .ToListAsync();
            var dailyHealths = await _myDbContext.DailyHealths
                .Where(x => x.Date == date && employeeIds.Contains(x.EmployeeId))
                .ToListAsync();

            return dailyHealths;
        }

        public async Task UpdateForDepartmentAsync(int departmentId, DateTime date, IList<DailyHealth> dailyHealths)
        {
            var employeeIds = await _myDbContext.Employees
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => x.Id)
                .ToListAsync();
            var inDb = await _myDbContext.DailyHealths
                .Where(x => x.Date == date && employeeIds.Contains(x.EmployeeId))
                .ToListAsync();

            foreach (var dbItem in inDb)
            {
                var one = dailyHealths.SingleOrDefault(x => x.EmployeeId == dbItem.EmployeeId && x.Date == dbItem.Date);
                dbItem.HealthCondition = one.HealthCondition;
                dbItem.Temperature = one.Temperature;
                dbItem.Remark = one.Remark;
                _myDbContext.Update(dbItem);
            }

            var dbKeys = inDb.Select(x => new { x.EmployeeId, x.Date }).ToList();
            var incomingsKeys = dailyHealths.Select(x => new { x.EmployeeId, x.Date }).ToList();
            var toAddKeys = incomingsKeys.Except(dbKeys);
            foreach (var item in toAddKeys)
            {
                var todd = dailyHealths.Single(x => x.EmployeeId == item.EmployeeId && x.Date == item.Date);
                await _myDbContext.AddAsync(item);
            }

            var toRemoveKeys = dbKeys.Except(incomingsKeys);
            foreach (var item in toRemoveKeys)
            {
                var toRemove = inDb.Single(x => x.EmployeeId == item.EmployeeId && x.Date == item.Date);
                _myDbContext.Remove(item);
            }

            await _myDbContext.SaveChangesAsync();
        }
    }
}
