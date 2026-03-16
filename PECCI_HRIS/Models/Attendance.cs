using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class Attendance
    {
        [Key]
        public int attendanceID { get; set; }
        public string employeeID { get; set; }
        public DateTime attendanceDate { get; set; }
        public TimeSpan? timeIn { get; set; } // Using TimeSpan for SQL TIME types
        public TimeSpan? timeOut { get; set; }
        public short? tardinessMins { get; set; } // Using short for SQL SMALLINT
        public short? undertimeMins { get; set; }
    }
}