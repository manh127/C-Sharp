using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Models;

namespace ClinicAPI.Request
{
    public class CreatePrescriptionRequest
    {
        public Guid? IdSchedule { get; set; }
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Code { get; set; }
        public List<PrescriptionMedicineModels> Medicines { get; set; }
    }

    
}
