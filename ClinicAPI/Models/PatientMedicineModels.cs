using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class PatientMedicineModels
    {

        public string NameMedicine { get; set; }
        public int Quantity { get; set; }
        public double PriceMedicine { get; set; }
        public double TotalPrice { get; set; }
    }
}
