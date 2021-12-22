using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class ScheduleOfPatientModel
    {
        public Guid Id { get; set; }
        public string NameDoctor { get; set; }
        public Guid IdDoctor { get; set; }
        public long DateTimeStamp { get; set; }
        public string ServiceName { get; set; }
        public double ServicePrice { get; set; }
    }
}
