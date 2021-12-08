using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class Revenue
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid ScheduleId { get; set;}
        [Column(TypeName = "varchar(40)")]
        public Guid ServiceId { get; set; }
        public DateTime Time { get; set; }
    }
}
