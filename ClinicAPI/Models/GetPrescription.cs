using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class GetPrescription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Code { get; set; }

    }
}

