using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class CreateScheduleRequest
    {
       // public async Task<bool> CreateSchedule(Guid DoctorId, Guid PatientId, long DateTimeStamp, int Status, List<Guid> serviceIds)
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public long DateTimeStamp { get; set; }
        public int Status { get; set; }
        public List<Guid> ServiceIds { get; set; }

    }
}
