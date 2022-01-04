using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class GetDetailPrescription
    {
        public Guid Id { get; set; }
        public Guid? IdSchedule { get; set; }
        public string Name { get; set; }
        public double TimeStamp { get; set; }
        public string Code { get; set; }
        public List<PrescriptionMedicineModels> Medicines { get; set; }
    }
}
