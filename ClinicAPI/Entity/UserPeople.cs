using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class UserPeople
    {
        [Column(TypeName = "varchar(100)")]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public string Job { get; set; }
        public string Avatar { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
