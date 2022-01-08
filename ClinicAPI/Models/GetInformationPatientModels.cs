using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class GetInformationPatientModels
    {
        public string NamePatient { get; set; }
        public int YearOfBirth { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public string Job { get; set; }
        public double TimeStampPaid { get; set; }
        public string Service { get; set; }
        public double PriceService { get; set; }
        public double PriceSchedule { get; set; }
        public string TimeStampSchedule { get; set; }
        public string NamePrescription { get; set; }
        public List<PatientMedicineModels> Medicine { get; set; }
        
        

    }
}
