using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.EntityFrameworkCore;

namespace BlazorRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDbContext _myDbContext;

        public EmployeeRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _myDbContext.AddAsync<Employee>(employee);
            var count = await _myDbContext.SaveChangesAsync();
            if (count != 1) throw new Exception("新增失败");
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _myDbContext.Employees.FindAsync(id);
            _myDbContext.Employees.Remove(e);
            var count = await _myDbContext.SaveChangesAsync();
        }

        public async Task<IList<Employee>> GetForDepartmentAsync(int departmentId)
        {
            return await _myDbContext.Employees
                .Where(x => x.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<Employee> GetOneAsync(int id)
        {
            return await _myDbContext.FindAsync<Employee>(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _myDbContext.Attach(employee);
            _myDbContext.Employees.Update(employee);
            var count = await _myDbContext.SaveChangesAsync();
        }
    }
}
