using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class GetInfomationPatientt
    {
        public Guid IdPatient { get; set; }
        public Guid  IdSchedule { get; set; }
    }
}
