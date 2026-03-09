using Microsoft.EntityFrameworkCore;
using PECCI_HRIS.Models;

namespace PECCI_HRIS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Links the C# Code to the SQL tables created
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method first to ensure identity/core configs are loaded
            base.OnModelCreating(modelBuilder);

            // Mapping C# Models to actual SQL Table Names
            modelBuilder.Entity<EmployeeInfo>().ToTable("tbl_employee_info");
            modelBuilder.Entity<UserAccount>().ToTable("tbl_user_account");
            modelBuilder.Entity<LeaveRequest>().ToTable("tbl_leave_request");
        }
    }
}