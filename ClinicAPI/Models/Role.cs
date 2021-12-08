using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class Role
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
