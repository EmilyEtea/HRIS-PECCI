using Microsoft.EntityFrameworkCore;
using PECCI_HRIS.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PECCI_HRIS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Links the C# Code to the SQL tables created
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInfo>().ToTable("tbl_employee_info");
            modelBuilder.Entity<UserAccount>().ToTable("tbl_user_account")
        }
    }
}