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
        public List<ServiceDoctor> ServiceDoctors { get; set; }
    }
    public class ServiceDoctor
    {
        public Guid Id { get; set; }
        public string NameService { get; set; }
        public int Price { get; set; }
    }
}
