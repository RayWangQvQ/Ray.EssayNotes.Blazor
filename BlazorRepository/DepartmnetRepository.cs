using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.EntityFrameworkCore;

namespace BlazorRepository
{
    public class DepartmnetRepository : IDepartmnetRepository
    {
        private readonly MyDbContext _myDbContext;

        public DepartmnetRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            List<Department> re = await _myDbContext.Departments.ToListAsync();
            return re;
        }

        public async Task<Department> GetByIdAsync(int departmentId)
        {
            var one = await _myDbContext.FindAsync<Department>(departmentId);
            return one;
        }
    }
}
