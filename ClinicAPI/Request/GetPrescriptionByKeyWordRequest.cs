using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class GetPrescriptionByKeyWordRequest
    {
        public int? BySchedule { get; set; }
        public string KeyWord { get; set; }
    }
}
