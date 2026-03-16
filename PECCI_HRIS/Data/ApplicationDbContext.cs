using Microsoft.EntityFrameworkCore;
using PECCI_HRIS.Models;
using System.Globalization;

namespace PECCI_HRIS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Links the C# Code to the SQL tables created
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        // NEW TABLES: Added for the complete HRIS schema
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<EmployeeResidentialAddress> EmployeeResidentialAddresses { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<BeneficiaryInfo> BeneficiaryInfos { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
        public DbSet<PayrollRecord> PayrollRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method first to ensure identity/core configs are loaded
            base.OnModelCreating(modelBuilder);

            // Mapping C# Models to actual SQL Table Names
            modelBuilder.Entity<EmployeeInfo>().ToTable("tbl_employee_info");
            modelBuilder.Entity<UserAccount>().ToTable("tbl_user_account");
            modelBuilder.Entity<LeaveRequest>().ToTable("tbl_leave_request");

            // NEW TABLES: Explicit table mapping
            modelBuilder.Entity<CompanyInfo>().ToTable("tbl_company_info");
            modelBuilder.Entity<Compensation>().ToTable("tbl_compensation");
            modelBuilder.Entity<EmployeeResidentialAddress>().ToTable("tbl_employee_residential_address");
            modelBuilder.Entity<ContactPerson>().ToTable("tbl_contact_person");
            modelBuilder.Entity<BeneficiaryInfo>().ToTable("tbl_beneficiary_info");
            modelBuilder.Entity<Attendance>().ToTable("tbl_attendance");
            modelBuilder.Entity<OvertimeRequest>().ToTable("tbl_overtime_request");
            modelBuilder.Entity<PayrollRecord>().ToTable("tbl_payroll_record");
        }
    }
}