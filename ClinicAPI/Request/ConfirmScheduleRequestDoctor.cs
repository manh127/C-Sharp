using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class ConfirmScheduleRequestDoctor
    {
        public Guid ScheduleID { get; set; }
        public int Status { get; set; }
    }
}
