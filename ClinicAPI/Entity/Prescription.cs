using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class Prescription
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid IdMedicine { get; set; }
        public string NameMedicine { get; set; }
        public string UseMedicine { get; set; }
        public string Unit { get; set; }
        public string Quantily { get; set; }
        public string PriceMedicine { get; set; }
    }
}
