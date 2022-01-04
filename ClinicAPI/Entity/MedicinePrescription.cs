using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class MedicinePrescription
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid IdPrescription { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid IdMedicine { get; set; }
        public int QuantilyMedicine { get; set; }
    }
}
