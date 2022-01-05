using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class UpdateScheduleRequest
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public string DateTimeStamp { get; set; }
        public int Status { get; set; }
        public Guid ServiceId { get; set; }
    }
}
