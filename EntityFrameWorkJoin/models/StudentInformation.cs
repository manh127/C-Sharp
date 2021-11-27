using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.models
{
    [Table("studentinformation")]
   public class StudentInformation
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int YearOfBirth { get; set; }
    }
}
