using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class OvertimeRequest
    {
        [Key]
        public int overtimeRequestID { get; set; }
        public string employeeID { get; set; }
        public DateTime overtimeDate { get; set; }
        public string overtimeReason { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public decimal numOfHours { get; set; }
        public string supervisorSignature { get; set; }
        public string supervisorStatus { get; set; }
        public string gmSignature { get; set; }
        public string gmStatus { get; set; }
        public DateTime dateFiled { get; set; }
    }
}