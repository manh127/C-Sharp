using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class Schedule
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid DoctorId { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid PatientId { get; set; }
        [Column(TypeName = "varchar(40)")]
        public long DateTimeStamp { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid ServiceId { get; set; }
    }
}
