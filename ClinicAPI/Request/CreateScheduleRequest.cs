using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class CreateScheduleRequest
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string DateTimeStamp { get; set; }
        public string ServiceId { get; set; }
        public int Status { get; set; }
        public string Id { get; set; }
    }
}
