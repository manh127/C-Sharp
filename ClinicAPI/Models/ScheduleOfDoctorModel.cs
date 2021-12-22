using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class ScheduleOfDoctorModel
    {
        public Guid Id { get; set; }
        public string NamePatient { get; set; }
        public Guid IdPatient { get; set; }
        public long DateTimeStamp { get; set; }
        public string ServiceName { get; set; }
        public double ServicePrice { get; set; }
    }
}
