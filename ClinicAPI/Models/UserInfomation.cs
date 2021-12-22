using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class UserInfomation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public int YearOfBirth { get; set; }
    }
}
