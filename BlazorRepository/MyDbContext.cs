using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDomain;
using Microsoft.EntityFrameworkCore;

namespace BlazorRepository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyHealth>().HasKey(x => new
            {
                x.EmployeeId,
                x.Date
            });

            modelBuilder.Entity<Employee>().HasOne<Department>().WithMany().HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DailyHealth>().HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "研发部" },
                new Department() { Id = 2, Name = "销售部" },
                new Department { Id = 3, Name = "采购部" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    DepartmentId = 1,
                    No = "A01",
                    Name = "Nicky Carter",
                    BirthDate = new DateTime(1980, 1, 1)
                },
                new Employee
                {
                    Id = 2,
                    DepartmentId = 1,
                    No = "A02",
                    Name = "Mike",
                    BirthDate = new DateTime(1982, 1, 1)
                },
                new Employee
                {
                    Id = 3,
                    DepartmentId = 2,
                    No = "B01",
                    Name = "Bob",
                    BirthDate = new DateTime(1995, 1, 1)
                },
                new Employee
                {
                    Id = 4,
                    DepartmentId = 2,
                    No = "B02",
                    Name = "Mary",
                    BirthDate = new DateTime(1979, 1, 1)
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<DailyHealth> DailyHealths { get; set; }
    }
}
