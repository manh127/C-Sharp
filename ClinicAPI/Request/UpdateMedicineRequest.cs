﻿using System;
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
 
        public string Quantily { get; set; }

       // public int Quantily { get; set; }

        public string PriceMedicine { get; set; }
    }
}
