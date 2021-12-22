using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class Revenue
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid ScheduleId { get; set;}
        public long Time { get; set; }
        public double Price { get; set; }
    }
}
