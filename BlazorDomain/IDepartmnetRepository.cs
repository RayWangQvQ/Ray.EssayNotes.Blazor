using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDomain
{
    public interface IDepartmnetRepository
    {
        Task<List<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int departmentId);
    }
}
