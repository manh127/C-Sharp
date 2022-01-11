using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class PatientMedicineModels
    {

        public string NameMedicine { get; set; }
        public string Quantity { get; set; }
        public double PriceMedicine { get; set; }
        public Int64 TotalPrice { get; set; }

        public int QuantilyMedicine { get; set; }
    }
}
