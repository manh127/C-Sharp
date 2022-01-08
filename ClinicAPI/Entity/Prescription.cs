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
<<<<<<< HEAD

        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid? IdSchedule { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double TimeStamp { get; set; }
=======
        public Guid IdMedicine { get; set; }
        public string NameMedicine { get; set; }
        public string UseMedicine { get; set; }
        public string Unit { get; set; }
        public int Quantily { get; set; }
        public string PriceMedicine { get; set; }
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
    }
}
