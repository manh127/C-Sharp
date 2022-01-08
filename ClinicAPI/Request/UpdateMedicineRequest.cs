using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class UpdateMedicineRequest
    {

        public Guid IdMedicine { get; set; }
        public string NameMedicine { get; set; }
        public string UseMedicine { get; set; }
        public string Unit { get; set; }
<<<<<<< HEAD
        public string Quantily { get; set; }
=======
        public int Quantily { get; set; }
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
        public string PriceMedicine { get; set; }
    }
}
