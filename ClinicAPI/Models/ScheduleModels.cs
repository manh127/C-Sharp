using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAPI.Models
{
    public class ScheduleModels
    {
        
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public string NameDoctor { get; set; }
        public Guid PatientId { get; set; }
        public string NamePatient { get; set; }
        public List<ServiceModels> Services { get; set; }
        public long DateTimeStamp { get; set; }
        public int Status { get; set; }
    }
}
