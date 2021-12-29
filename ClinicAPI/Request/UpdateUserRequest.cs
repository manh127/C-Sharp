using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Request
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public string Job { get; set; }
        public string? Avatar { get; set; }
        public string? Note1 { get; set; }
        public string? Note2 { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
