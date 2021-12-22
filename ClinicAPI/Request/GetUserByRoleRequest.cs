using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class GetUserByRoleRequest
    {
        public string Code { get; set; }
        public string KeyWord { get; set;}
    }
}
